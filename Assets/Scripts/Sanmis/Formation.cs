using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{

    [SerializeField] private NodeChain[] nodeChains;
    int NumNodeChains => nodeChains.Length;


    // testing
    private void Start()
    {
        for (int i = 0; i < NumNodeChains; ++i)
        {
            Debug.Log("Node chain " + i);
            nodeChains[i].PrintNodes();
        }
    }


    private int GetBelongingNodeChainIndex(int nodeIndex)
    {
        return nodeIndex % NumNodeChains;
    }

    private int GetIndexInBelongingNodeChain(int nodeIndex)
    {
        return nodeIndex / NumNodeChains;
    }


    public void ArrangeNewNode(Node newNode)
    {
        nodeChains[GetBelongingNodeChainIndex(newNode.index)].AddNewNode(newNode);
    }

    public void RearrangeAll(List<Node> allNodes)
    {
        for (int i = 0; i < allNodes.Count; ++i)
        {
            allNodes[i].index = i;
            nodeChains[GetBelongingNodeChainIndex(i)].AddNewNode(allNodes[i]);
        }
        
    }


}
