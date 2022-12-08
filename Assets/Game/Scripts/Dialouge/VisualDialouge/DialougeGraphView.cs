#if UNITY_EDITOR

using System;
using System.Collections.Generic;
//using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{
    public class DialougeGraphView : GraphView
    {
        //public Action<CommentNode> OnNodeSelected;  //TODO standardize nodeview so Inspector can use it
        public DialougeBlackboard blackboard;
        private NodeSearchWindow _searchWindow;

        public DialougeGraphView(EditorWindow editorWindow)
        {
            styleSheets.Add(Resources.Load<StyleSheet>("DialougeGraph"));
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());

            var grid = new GridBackground();
            Insert(0,grid);
            grid.StretchToParentSize();

            AddElement(GenerateEntryPointNode());
            AddSearchWindow(editorWindow);
        }

        private void AddSearchWindow(EditorWindow editorWindow)
        {
            _searchWindow = ScriptableObject.CreateInstance<NodeSearchWindow>();
            _searchWindow.Init(editorWindow, this);
            nodeCreationRequest = context => 
            SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), _searchWindow);
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            var compatiblePorts = new List<Port>();
            ports.ForEach((port) =>
            {
                if(startPort!=port && startPort.node != port.node)
                {
                    compatiblePorts.Add(port);
                }
            });
            return compatiblePorts;
        }


        private DialougeNode GenerateEntryPointNode()
        {
            var node = new DialougeNode()
            {
                title = "START",
                GUID = Guid.NewGuid().ToString(),
                dialogueText = "ENTRYPOINT",
                entryPoint = true
            };

            var generatedPort = PortHelper.GeneratePort(node, Direction.Output);
            generatedPort.portName = "Dialouge Start";
            node.outputContainer.Add(generatedPort);


            //node.capabilities &= ~Capabilities.Movable;
            node.capabilities &= ~Capabilities.Deletable;
            node.RefreshExpandedState();
            node.RefreshPorts();

            node.SetPosition(new Rect(300, 200, 100, 150));
            return node;
        }

        public void CreateDialougeNode(Vector2 position)
        {
            DialougeNode dialougeNode = new DialougeNode(position, this)
            {
                GUID = Guid.NewGuid().ToString()
            };
            AddElement(dialougeNode);
        }

        public void CreateCommentNode(string nodeName, Vector2 position)
        {
            CommentNode dialougeNode = new CommentNode(nodeName, position, this)
            {
                title = nodeName,
                CommentText = nodeName,
                GUID = Guid.NewGuid().ToString()
            };
            AddElement(dialougeNode);
        }
    }
}

#endif