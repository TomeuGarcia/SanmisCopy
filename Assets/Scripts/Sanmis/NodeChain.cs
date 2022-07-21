using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeChain : MonoBehaviour
{
    private enum ChainType { Constant, Function };
    [SerializeField] private ChainType chainType;

    public Node lastNode { get; private set; }

    [SerializeField] Vector3 chainPositionOffset = -Vector3.forward;

    [SerializeField] AnimationCurve functionX;


    private void Awake()
    {
        lastNode = null;
    }


    public void ResetNodes()
    {
        lastNode = null;
    }

    public void AddNewNode(Node newNode, int nodeIndexInChain)
    {
        if (lastNode != null)
        {
            lastNode.next = newNode;
            newNode.previous = lastNode;
        }
        
        lastNode = newNode;

        SetNodePosition(newNode, nodeIndexInChain);
    }


    public void RemoveNodeWithIndex(int nodeIndex)
    {
        Node tempNode = lastNode;
        while (tempNode.index != nodeIndex)
        {
            tempNode = tempNode.previous;
        }

        tempNode.isRemoved = true;

        if (tempNode == lastNode)
        {
            lastNode = tempNode.previous;
        }
    }

    public void RemoveNodesWithAndAfterIndex(int nodeIndex)
    {
        while (lastNode.index != nodeIndex)
        {
            lastNode.isRemoved = true;
            lastNode = lastNode.previous;
        }

        lastNode.isRemoved = true;
        lastNode = lastNode.previous;

    }


    private void SetNodePosition(Node newNode, int nodeIndexInChain)
    {
        newNode.SetAttachedNodeChain(nodeIndexInChain, this);
    }

    public Vector3 GetPositionInChain(int nodeIndexInChain)
    {
        if (chainType == ChainType.Constant)
        {
            return transform.position + ((float)nodeIndexInChain * transform.TransformDirection(chainPositionOffset));
        }
        else if (chainType == ChainType.Function)
        {
            return transform.position + transform.TransformDirection(new Vector3(functionX.Evaluate(nodeIndexInChain), 0.0f, -1.0f * nodeIndexInChain));
        }

        return Vector3.zero;
    }


}
