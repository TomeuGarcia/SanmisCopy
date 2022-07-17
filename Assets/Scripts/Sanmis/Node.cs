using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int index;
    public Node previous;
    public Node next;

    private void Awake()
    {
        previous = null;
        next = null;
    }
}
