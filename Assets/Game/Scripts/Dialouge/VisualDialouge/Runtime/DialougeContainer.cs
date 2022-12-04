using System;
using System.Collections.Generic;
using UnityEngine;

namespace VisualDialougeTree
{
    [Serializable]
    public class DialougeContainer : ScriptableObject
    {
        public List<NodeLinkData> nodeLinks = new List<NodeLinkData>();
        public List<DialougeNodeData> dialougeNodeData = new List<DialougeNodeData>();
        public List<DialougeNodeData> commentNodeData = new List<DialougeNodeData>();
        public List<ExposedProperty> ExposedProperties = new List<ExposedProperty>();

        public DialougeNodeData getEntryNode()
        {
            return dialougeNodeData[0];
        }
    }
}