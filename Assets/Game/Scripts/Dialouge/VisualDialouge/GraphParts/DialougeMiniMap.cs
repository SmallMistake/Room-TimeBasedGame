
#if UNITY_EDITOR

using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace VisualDialougeTree
{

    public class DialougeMiniMap : MiniMap
    {

        public DialougeMiniMap(DialougeGraphView _graphView)
        {
            GenerateMiniMap(_graphView);
        }

        private void GenerateMiniMap(DialougeGraphView _graphView)
        {
            anchored = true;
            //Give Left Offset
            var coords = _graphView.contentViewContainer.WorldToLocal(new Vector2(50, 30)); //TODO Fix this shit Mip Map is being thrown all the way to 4000 x
            SetPosition(new Rect(50, coords.y, 200, 140));
        }
    }
}

#endif