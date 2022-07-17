using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeChain : MonoBehaviour
{
    public Node lastNode { get; private set; }
    //public int numNodes { get; private set; }



    private void Awake()
    {
        //numNodes = 0;
        lastNode = null;
    }


    public void AddNewNode(Node newNode)
    {
        //++numNodes;

        if (lastNode != null)
        {
            lastNode.next = newNode;
            newNode.previous = lastNode;
        }
        
        lastNode = newNode;
    }

    public void PrintNodes()
    {
        Node tempNode = lastNode;
        while (tempNode != null)
        {
            Debug.Log(tempNode.index);
            tempNode = tempNode.previous;
        }
    }

}
