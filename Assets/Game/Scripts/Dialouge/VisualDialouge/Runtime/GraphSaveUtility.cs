
#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{

    public class GraphSaveUtility
    {
        private DialougeGraphView _targetGraphView;
        private DialougeContainer _containerCache;
        private List<Edge> edges => _targetGraphView.edges.ToList();
        private List<DialougeNode> nodes => _targetGraphView.nodes.OfType<DialougeNode>().ToList();  //.Cast<DialougeNode>().ToList();
        private List<CommentNode> comments => _targetGraphView.nodes.OfType<CommentNode>().ToList();

        public static GraphSaveUtility GetInstance(DialougeGraphView targetGraphView)
        {
            return new GraphSaveUtility
            {
                _targetGraphView = targetGraphView
            };
        }

        public void SaveGraph(string fileName)
        {
            var dialougeContainer = ScriptableObject.CreateInstance<DialougeContainer>();
            if (!SaveNodes(dialougeContainer))
            {
                EditorUtility.DisplayDialog(
                "No Dialouge Saved",
                "No savable data was found",
                "OK"
            );
                return;
            };
            SaveExposedProperties(dialougeContainer);

            //Save Asset to this Location
            if (!AssetDatabase.IsValidFolder("Assets/Resources"))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
            }
            if (!AssetDatabase.IsValidFolder("Assets/Resources/Dialouge"))
            {
                AssetDatabase.CreateFolder("Assets/Resources", "Dialouge");
            }

            AssetDatabase.CreateAsset(dialougeContainer, $"Assets/Resources/Dialouge/{fileName}.asset");
            AssetDatabase.SaveAssets();
            EditorUtility.DisplayDialog(
                "Successfully Saved Dialouge", 
                $"File Name: {fileName}\n" +
                $"Location: Assets/Resources/Dialouge\n" +
                    $"Nodes: {nodes.Count}\n" +
                    $"Edges: {edges.Count}",
                "OK"
            );
        }

        public void LoadGraph(string fileName)
        {
            _containerCache = Resources.Load<DialougeContainer>("Dialouge/" + fileName);
            if (_containerCache == null)
            {
                EditorUtility.DisplayDialog("File Not Found", "Target dialouge graph file does not exist!", "OK");
                return;
            }
            ClearGraph();
            CreateNodes();
            LoadComments();
            ConnectNodes();
            CreateExposedProperties();
        }

        private void CreateExposedProperties()
        {
            //Clear existing properties on hot-reload
            _targetGraphView.blackboard.ClearBlackBoardAndExposedProperties();
            //Add properties from data
            foreach(var exposedProperty in _containerCache.ExposedProperties)
            {
                _targetGraphView.blackboard.AddPropertyToBlackboard(exposedProperty);
            }
        }

        //This is the primary Save Function
        private bool SaveNodes(DialougeContainer dialougeContainer)
        {
            //TODO add cooldown warning because System Errors if you save to many times to fast
            //if (!edges.Any() && !commentsToSave) return false; // TODO Replace this with if 0 0 0 in all fields return false at end

            dialougeContainer = SaveComments(dialougeContainer);
            dialougeContainer = SaveEdges(dialougeContainer);
            dialougeContainer = SaveDialougeNodes(dialougeContainer);
            return true;
        }

        private DialougeContainer SaveComments(DialougeContainer dialougeContainer)
        {
            foreach (var commentNode in comments)
            {
                dialougeContainer.commentNodeData.Add(new DialougeNodeData
                {
                    GUID = commentNode.GUID,
                    dialougeText = commentNode.CommentText,
                    position = commentNode.GetPosition().position
                });
            }
            return dialougeContainer;
        }

        private DialougeContainer SaveEdges(DialougeContainer dialougeContainer)
        {
            var connectedPorts = edges.Where(x => x.input.node != null).ToArray();
            for (var i = 0; i < connectedPorts.Length; i++)
            {
                var outputNode = connectedPorts[i].output.node as DialougeNode;
                var inputNode = connectedPorts[i].input.node as DialougeNode;

                dialougeContainer.nodeLinks.Add(new NodeLinkData
                {
                    baseNodeGuid = outputNode.GUID,
                    portName = connectedPorts[i].output.portName,
                    targetNodeGuid = inputNode.GUID
                });
            }
            return dialougeContainer;
        }

        private DialougeContainer SaveDialougeNodes(DialougeContainer dialougeContainer)
        {
            foreach (var dialougeNode in nodes.Where(node => !node.entryPoint))
            {
                dialougeContainer.dialougeNodeData.Add(new DialougeNodeData
                {
                    GUID = dialougeNode.GUID,
                    dialougeText = dialougeNode.dialogueText,
                    position = dialougeNode.GetPosition().position
                });
            }
            return dialougeContainer;
        }

        private void SaveExposedProperties(DialougeContainer dialougeContainer)
        {
            dialougeContainer.ExposedProperties.AddRange(_targetGraphView.blackboard.exposedProperties);
        }

        private void CreateNodes()
        {
            foreach (var nodeData in _containerCache.dialougeNodeData)
            {
                var tempNode = new DialougeNode(Vector2.zero, _targetGraphView, nodeData.dialougeText)
                {
                    GUID = nodeData.GUID
                };
                _targetGraphView.AddElement(tempNode);

                var nodePorts = _containerCache.nodeLinks.Where(x => x.baseNodeGuid == nodeData.GUID).ToList();
                nodePorts.ForEach(x => PortHelper.AddChoicePort(tempNode, _targetGraphView, x.portName));
            }
        }

        private void ClearGraph()
        {
            //Set entry points guid back from the save. Discard existing guid
            nodes.ToList().Find(x => x.entryPoint).GUID = _containerCache.nodeLinks[0].baseNodeGuid;


            //Remove Dialouge Nodes
            foreach (var node in nodes)
            {
                if (node.entryPoint) continue;
                //Remove edges connected to node
                edges.Where(x => x.input.node == node).ToList()
                    .ForEach(edge => _targetGraphView.RemoveElement(edge));

                //Remove Node
                _targetGraphView.RemoveElement(node);
            }

            //Remove Comment Nodes TODO
            foreach (var comment in comments)
            {
                //Remove Node
                _targetGraphView.RemoveElement(comment);
            }
        }

        private void ConnectNodes()
        {
            foreach (var node in nodes)
            {
                var connections = _containerCache.nodeLinks.Where(x => x.baseNodeGuid == node.GUID).ToList();
                for (var j = 0; j < connections.Count; j++)
                {
                    var targetNodeGuid = connections[j].targetNodeGuid;
                    var targetNode = nodes.First(node => node.GUID == targetNodeGuid);
                    LinkNodes(node.outputContainer[j].Q<Port>(), (Port)targetNode.inputContainer[0]);

                    targetNode.SetPosition(new Rect(
                        _containerCache.dialougeNodeData.First(x => x.GUID == targetNodeGuid).position,
                        DialougeNode.defaultNodeSize
                    ));
                }
            }
        }

        private void LoadComments()
        {
            foreach (var nodeData in _containerCache.commentNodeData)
            {
                var tempNode = new CommentNode(nodeData.dialougeText, nodeData.position, _targetGraphView)
                {
                    GUID = nodeData.GUID
                };
                _targetGraphView.AddElement(tempNode);
            }
        }

        private void LinkNodes(Port output, Port input)
        {
            var tempEdge = new Edge()
            {
                output = output,
                input = input
            };

            tempEdge?.input.Connect(tempEdge);
            tempEdge?.output.Connect(tempEdge);
            _targetGraphView.Add(tempEdge);
        }
    }
}

#endif