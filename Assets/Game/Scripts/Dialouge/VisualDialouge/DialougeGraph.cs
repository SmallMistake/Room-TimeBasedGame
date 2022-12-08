
#if UNITY_EDITOR

//using System.Linq;
using UnityEditor;
//using UnityEditor.Experimental.GraphView;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{
    //This class is responsible for generating the Toolbar, MiniMap, Blackboard, GraphView
    public class DialougeGraph : EditorWindow
    {
        private DialougeGraphView _graphView;
        private string _fileName = "New Narrative";

        [MenuItem("Graph/Dialouge Graph")]
        public static void OpenDialougeGraphWindow()
        {
            var window = GetWindow<DialougeGraph>();
            window.titleContent = new GUIContent("Dialouge Graph");
        }


        private void OnEnable()
        {
            ConstructGraphView();
            GenerateBlackBoard();
            GenerateToolbar();
            //GenerateMiniMap(); //TODO Fix
        }

        private void OnDisable()
        {
            rootVisualElement.Remove(_graphView);
        }

        private void ConstructGraphView()
        {
            _graphView = new DialougeGraphView(this)
            {
                name = "Dialouge Graph"
            };

            _graphView.StretchToParentSize();
            rootVisualElement.Add(_graphView);
        }

        private void GenerateToolbar()
        {
            var toolbar = new DialougeToolbar(_fileName, _graphView);

            rootVisualElement.Add(toolbar);
        }

        private void GenerateMiniMap()
        {
            _graphView.Add(new DialougeMiniMap(_graphView));
        }

        private void GenerateBlackBoard()
        {
            DialougeBlackboard blackboard = new DialougeBlackboard(_graphView);
            _graphView.Add(blackboard);
            _graphView.blackboard = blackboard;
        }
    }
}

#endif