using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{

    [SerializeField] private NodeChain[] nodeChains;
    int NumNodeChains => nodeChains.Length;



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
        nodeChains[GetBelongingNodeChainIndex(newNode.index)].AddNewNode(newNode, GetIndexInBelongingNodeChain(newNode.index));
    }

    public void ArrangeAll(List<Node> allNodes)
    {
        for (int i = 0; i < nodeChains.Length; ++i)
        {
            nodeChains[i].ResetNodes();
        }

        for (int i = 0; i < allNodes.Count; ++i)
        {
            allNodes[i].index = i; // not sure
            nodeChains[GetBelongingNodeChainIndex(i)].AddNewNode(allNodes[i], GetIndexInBelongingNodeChain(allNodes[i].index));
        }
        
    }


    public void RemoveNodeWithIndex(int nodeIndex)
    {
        nodeChains[GetBelongingNodeChainIndex(nodeIndex)].RemoveNodeWithIndex(nodeIndex);
    }

    public void RemoveNodesWithAndAfterIndex(int nodeIndex)
    {
        nodeChains[GetBelongingNodeChainIndex(nodeIndex)].RemoveNodesWithAndAfterIndex(nodeIndex);
    }


}
