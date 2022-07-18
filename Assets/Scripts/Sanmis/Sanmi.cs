using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanmi : MonoBehaviour
{
    public Node node;
    public SanmiCollider sanmiCollider;
    [SerializeField] private SanmiMovement sanmiMovement;

    public enum SanmiType { Normal };
    [SerializeField] SanmiType sanmiType;


    private void Awake()
    {
        sanmiCollider.Init(node, sanmiMovement);
    }

}
