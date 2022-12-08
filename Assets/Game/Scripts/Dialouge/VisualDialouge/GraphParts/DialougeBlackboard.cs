#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{
    public class DialougeBlackboard : Blackboard
    {
        public List<ExposedProperty> exposedProperties = new List<ExposedProperty>();

        public DialougeBlackboard(DialougeGraphView _graphView)
        {
            title = "Exposed Properties";
            GenerateBlackBoard(_graphView);
            style.maxWidth = 400;
            style.minWidth = 260;

        }

        private void GenerateBlackBoard(DialougeGraphView _graphView)
        {
            graphView = _graphView;
            //Add(new BlackboardSection { title = "Exposed Properties" });
            scrollable = true;
            addItemRequested = _blackboard =>
            {
                AddPropertyToBlackboard(new ExposedProperty());
            };

            editTextRequested = (blackboard, element, newValue) =>
            {
                var oldPropertyName = ((BlackboardField)element).text;
                if (exposedProperties.Any(x => x.PropertyName == newValue))
                {
                    EditorUtility.DisplayDialog("Error", "This property name already exists, please choose another one!",
                        "OK");
                    return;
                }

                var propertyIndex = exposedProperties.FindIndex(x => x.PropertyName == oldPropertyName);
                exposedProperties[propertyIndex].PropertyName = newValue;
                ((BlackboardField)element).text = newValue;
            };
            SetPosition(new Rect(10, 30, 270, 300));
        }

        public void AddPropertyToBlackboard(ExposedProperty exposedProperty)
        {
            var localPropertyName = exposedProperty.PropertyName;
            var localPropertyValue = exposedProperty.PropertyValue;
            while (exposedProperties.Any(x => x.PropertyName == localPropertyName))
            {
                localPropertyName = incrementPropertyName(localPropertyName);
            }

            var property = new ExposedProperty();
            property.PropertyName = localPropertyName;
            property.PropertyValue = exposedProperty.PropertyValue;
            exposedProperties.Add(property);

            var mainContainer = new VisualElement();
            var subContainer = new VisualElement();
            var blackboardField = new BlackboardField { text = property.PropertyName, typeText = "string property" };
            blackboardField.style.backgroundColor = new Color(12f/255f, 10f / 255f, 58f / 255f);
            blackboardField.style.borderBottomLeftRadius = 10;
            blackboardField.style.borderBottomRightRadius = 10;
            blackboardField.style.borderTopLeftRadius = 10;
            blackboardField.style.borderTopRightRadius = 10;
            mainContainer.Add(blackboardField);

            var propertyValueTextField = new TextField("Value:")
            {
                value = localPropertyValue
            };

            propertyValueTextField.RegisterValueChangedCallback(evt =>
            {
                var changingPropertyIndex = exposedProperties.FindIndex(x => x.PropertyName == property.PropertyName);
                exposedProperties[changingPropertyIndex].PropertyValue = evt.newValue;
            });

            var deleteButton = new Button(() => {
                RemovePropertyFromBlackboard(property);
                Remove(mainContainer);
            });
            deleteButton.text = "Delete Property";
            deleteButton.style.backgroundColor = new Color(249f / 255f, 86f / 255f, 79f / 255f);
            deleteButton.style.maxWidth = 300;
            deleteButton.style.marginTop = 10f;
            deleteButton.style.alignSelf = Align.Center;

            subContainer.style.paddingTop = 10;
            subContainer.style.paddingBottom = 10;
            subContainer.style.paddingLeft = 10;
            subContainer.Add(propertyValueTextField);
            subContainer.Add(deleteButton);

            var blackBoardValueRow = new BlackboardRow(blackboardField, subContainer);
            mainContainer.Add(blackBoardValueRow);

            Add(mainContainer);
        }

        public void RemovePropertyFromBlackboard(ExposedProperty exposedProperty)
        {
            Debug.Log(exposedProperty.PropertyName);
            exposedProperties.Remove(exposedProperty);
        }

            public void ClearBlackBoardAndExposedProperties()
        {
            exposedProperties.Clear();
            Clear();
        }

        private string incrementPropertyName(string propertyName)
        {
            // Create a pattern for a word that starts with letter "M"  
            string pattern = @"\((\d+)\){1}$";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            MatchCollection matchedNumber = rg.Matches(propertyName);
            if (matchedNumber.Count > 0) // Increment Counter
            {
                string subPattern = @"\d+";
                // Create a Regex  
                Regex subRegex = new Regex(subPattern);
                MatchCollection number = subRegex.Matches(matchedNumber[0].Value);
                int versionNumber = int.Parse(number[0].Value);
                versionNumber++;
                propertyName = propertyName.Substring(0, propertyName.Length - matchedNumber[0].Value.Length) + $"({versionNumber})";
            }
            else
            {
                propertyName += " (1)";
            }
            return propertyName;
        }
    }
}

#endif