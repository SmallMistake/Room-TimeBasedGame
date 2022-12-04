using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisualDialougeTree;

public class DialougeReader
{
    DialougeContainer dialougeTree;
    DialougeNodeData currentNode;
    public DialougeReader(DialougeContainer dialouge)
    {
        dialougeTree = dialouge;
        currentNode = getEntryNode();
    }

    private DialougeNodeData getEntryNode()
    {
        NodeLinkData entryLink = dialougeTree.nodeLinks.Where(linkData => linkData.portName == "Dialouge Start").First();
        DialougeNodeData entryDialougeNode = dialougeTree.dialougeNodeData.Where(nodeData => nodeData.GUID == entryLink.targetNodeGuid).First();
        return entryDialougeNode;
    }
    public void readCurrentNode()
    {
        Debug.Log(currentNode.dialougeText);
    }

    //Return true if there is another node to move to false if at end of dialouge chain.
    public bool moveToNextNode(string choice = null)
    {
        
        List<NodeLinkData> possibleChoices =  dialougeTree.nodeLinks.Where(linkData => linkData.baseNodeGuid == currentNode.GUID).ToList();
        if(choice == null)
        {
            //currentNode = possibleChoices.First();
        }
        //TODO implment multiple choices

        return false;
    }
}
