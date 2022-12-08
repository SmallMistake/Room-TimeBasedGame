
#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{
    public static class PortHelper
    {
        internal static  Port GeneratePort(DialougeNode node, Direction portDirection, Port.Capacity capacity = Port.Capacity.Single)
        {
            return node.InstantiatePort(Orientation.Horizontal, portDirection, capacity, typeof(float)); ///Can change type it's not used
        }

        internal static void AddChoicePort(DialougeNode dialougeNode, DialougeGraphView _graphView, string overriddenPortName = "")
        {
            var generatedPort = GeneratePort(dialougeNode, Direction.Output);

            var oldLabel = generatedPort.contentContainer.Q<Label>("type");
            generatedPort.contentContainer.Remove(oldLabel);
            var outputPortCount = dialougeNode.outputContainer.Query("connector").ToList().Count;

            var choicePortName = string.IsNullOrEmpty(overriddenPortName)
                ? $"Choice {outputPortCount + 1}"
                : overriddenPortName;

            var textField = new TextField
            {
                name = string.Empty,
                value = choicePortName
            };
            textField.RegisterValueChangedCallback(evt => generatedPort.portName = evt.newValue);
            generatedPort.contentContainer.Add(new Label(" "));
            generatedPort.contentContainer.Add(textField);
            var deleteButton = new Button(() => RemovePort(dialougeNode, generatedPort, _graphView))
            {
                text = "X"
            };
            generatedPort.contentContainer.Add(deleteButton);

            generatedPort.portName = choicePortName;

            dialougeNode.outputContainer.Add(generatedPort);
            dialougeNode.RefreshPorts();
            dialougeNode.RefreshExpandedState();
        }

        private static void RemovePort(DialougeNode dialougeNode, Port generatedPort, DialougeGraphView _graphView)
        {

            var targetEdge = _graphView.edges.ToList().Where(x =>
            x.output.portName == generatedPort.portName && x.output.node == generatedPort.node);

            if (!targetEdge.Any()) return;
            var edge = targetEdge.First();
            edge.input.Disconnect(edge);
            _graphView.RemoveElement(edge);

            dialougeNode.outputContainer.Remove(generatedPort);
            dialougeNode.RefreshPorts();
            dialougeNode.RefreshExpandedState();
        }
    }
}

#endif