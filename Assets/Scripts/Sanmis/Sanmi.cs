using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanmi : MonoBehaviour
{
    public Node node;
    public SanmiCollider sanmiCollider;
    [SerializeField] private SanmiMovement sanmiMovement;

    public enum SanmiType { ZeroZero, Especial, Magna, YakimaValley, Selecta, COUNT };
    static public readonly string[] names = { "0,0", "Especial", "Magna", "Yakima Valley", "Selecta" };
    static public readonly int[] scores = { 100, 200, 400, 800, 1600 };
    public SanmiType sanmiType;


    private void Awake()
    {
        sanmiCollider.Init(node, sanmiMovement);
    }

}
