using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{

    public class DialougeToolbar : Toolbar
    {
        public DialougeToolbar(string _fileName, DialougeGraphView _graphView)
        {
            GenerateToolbar(_fileName,_graphView);
        }

        private void GenerateToolbar(string _fileName, DialougeGraphView _graphView)
        {
            var fileNameTextField = new TextField("File Name:");
            fileNameTextField.style.width = 400;
            fileNameTextField.SetValueWithoutNotify(_fileName);
            fileNameTextField.MarkDirtyRepaint();
            fileNameTextField.RegisterValueChangedCallback(evt => _fileName = evt.newValue);
            Add(fileNameTextField); //Add File name field

            Button saveButton = new Button(() => RequestDataOperation(_fileName, true, _graphView)) { text = "Save Data" };
            Button loadButton = new Button(() => RequestDataOperation(_fileName, false, _graphView)) { text = "Load Data" };
            Add(saveButton);  //Save and load buttons
            Add(loadButton);
            Add(new Button(() => FlipBlackBoardStatus(_graphView)) { text = "Toggle Blackboard" });
        }

        //Perform Saving or loading
        private void RequestDataOperation(string _fileName, bool save, DialougeGraphView _graphView)
        {
            if (string.IsNullOrEmpty(_fileName))
            {
                EditorUtility.DisplayDialog("Invalid file name!", "Please enter a valid file name.", "OK");
            }
            var saveUtility = GraphSaveUtility.GetInstance(_graphView);
            if (save)
            {
                saveUtility.SaveGraph(_fileName);
            }
            else
            {
                saveUtility.LoadGraph(_fileName);
            }
        }

        private void FlipBlackBoardStatus(DialougeGraphView _graphView)
        {
            _graphView.blackboard.visible = !_graphView.blackboard.visible;
        }
    }
}