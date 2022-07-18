using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    struct ChainPositionData
    {
        public ChainPositionData(int nodeIndexInChain, NodeChain nodeChain, float duration)
        {
            this.nodeIndexInChain = nodeIndexInChain;
            this.nodeChain = nodeChain;
            this.duration = duration;
        }

        public int nodeIndexInChain;
        public NodeChain nodeChain;
        public float duration;
    }

    public int index;
    public Node previous;
    public Node next;
    public bool isRemoved;


    public delegate void NodeSetChainAction(int nodeIndexInChain, NodeChain nodeChain);
    public NodeSetChainAction OnChainSet;




    private void Awake()
    {
        previous = null;
        next = null;
        isRemoved = false;
    }

    public void SetAttachedNodeChain(int nodeIndexInChain, NodeChain nodeChain)
    {
        if (OnChainSet != null) OnChainSet(nodeIndexInChain, nodeChain);
    }


    public void GetsKilled()
    {
        Destroy(gameObject);
    }

}
