using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{
    public class CommentNode : Node
    {
        public Action<CommentNode> OnNodeSelected;

        public static readonly Vector2 defaultNodeSize = new Vector2(500, 500);

        public string GUID;

        public string CommentText;

        public bool EntryPoint = false;

        public CommentNode() { }

        public CommentNode(string messageData, Vector2 position, DialougeGraphView _graphView) {
            CreateCommentNode(messageData, position, _graphView);
            //capabilities &= Capabilities.Resizable;
        }

        public void CreateCommentNode(string messageData, Vector2 position, DialougeGraphView _graphView)
        {
            styleSheets.Add(Resources.Load<StyleSheet>("CommentNode")); //TODO Comment Node

            var textField = new TextField()
            {
                multiline = true
            };
            title = "Comment Node";
            textField.RegisterValueChangedCallback(evt =>
            {
                CommentText = evt.newValue;
                //title = evt.newValue;
            });
            CommentText = messageData;
            textField.SetValueWithoutNotify(CommentText == "" ? "Enter Comment Here" : CommentText);
            mainContainer.Add(textField);

            RefreshExpandedState();
            SetPosition(new Rect(position, defaultNodeSize));
        }

        public override void OnSelected()
        {
            base.OnSelected();
            if(OnNodeSelected != null)
            {
                OnNodeSelected.Invoke(this); //TODO use this for the inspector
            }
        }
    }
}
