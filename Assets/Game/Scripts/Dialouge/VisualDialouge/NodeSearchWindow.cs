using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{
    public class NodeSearchWindow : ScriptableObject, ISearchWindowProvider
    {
        private DialougeGraphView _graphView;
        private EditorWindow _window;
        private Texture2D _indentationIcon;

        public void Init(EditorWindow window, DialougeGraphView graphView)
        {
            _graphView = graphView;
            _window = window;

            //Indentation Hack = Add Icon with Alpha of 0
            _indentationIcon = new Texture2D(1, 1);
            _indentationIcon.SetPixel(0, 0, new Color(0, 0, 0, 0));
            _indentationIcon.Apply();
        }

        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            var tree = new List<SearchTreeEntry>
        {
            new SearchTreeGroupEntry(new GUIContent("Create Elements"), 0),
            new SearchTreeGroupEntry(new GUIContent("Dialouge"), 1),
            new SearchTreeEntry(new GUIContent("Dialouge Node", _indentationIcon))
            {
                userData = new DialougeNode(), level = 2
            },
            new SearchTreeEntry(new GUIContent("Comment Node", _indentationIcon))
            {
                userData = new CommentNode(), level = 2
            }
        };
            return tree;
        }

        public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
        {
            var worldMousePosition = _window.rootVisualElement.ChangeCoordinatesTo(
                _window.rootVisualElement.parent, context.screenMousePosition- _window.position.position);
            var localMousePosition = _graphView.contentViewContainer.WorldToLocal(worldMousePosition);
            switch (SearchTreeEntry.userData)
            {
                case DialougeNode dialougeNode:
                    _graphView.CreateDialougeNode(localMousePosition);
                    return true;
                case CommentNode commentNode:
                    _graphView.CreateCommentNode("Comment Node", localMousePosition);
                    return true;
                default:
                    return false;
            }
        }
    }
}
