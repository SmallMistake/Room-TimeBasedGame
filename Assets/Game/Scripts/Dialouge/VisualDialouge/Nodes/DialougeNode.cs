#if UNITY_EDITOR

using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{
    public class DialougeNode : Node
    {
        public static readonly Vector2 defaultNodeSize = new Vector2(150, 200);

        public string GUID;

        public string dialogueText;

        public bool entryPoint = false;

        public DialougeNode() { }

        public DialougeNode (Vector2 position, DialougeGraphView _graphView, string messageData = null) {
            title = "Dialouge Node";
            CreateDialougeNode(messageData, position, _graphView);
        }

        public void CreateDialougeNode(string messageData, Vector2 position, DialougeGraphView _graphView)
        {
            var inputPort = PortHelper.GeneratePort(this, Direction.Input, Port.Capacity.Multi);
            inputPort.portName = "Input";
            inputContainer.Add(inputPort);

            styleSheets.Add(Resources.Load<StyleSheet>("Node"));

            var button = new Button(() =>
            {
                PortHelper.AddChoicePort(this, _graphView);
            });
            button.text = "New Choice";
            titleContainer.Add(button);

            var textField = new TextField();
            textField.RegisterValueChangedCallback(evt =>
            {
                dialogueText = evt.newValue;
            });
            dialogueText = messageData;
            textField.SetValueWithoutNotify(dialogueText == null ? "Enter Dialouge Here" : dialogueText);
            mainContainer.Add(textField);

            RefreshExpandedState();
            RefreshPorts();
            SetPosition(new Rect(position, defaultNodeSize));
        }
    }
}

#endif