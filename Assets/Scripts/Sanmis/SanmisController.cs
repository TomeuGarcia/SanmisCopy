using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanmisController : MonoBehaviour
{
    [SerializeField] PlayerInputs playerInputs;

    [SerializeField] private Transform sanmisRootTransform;
    [SerializeField, Range(0.0f, 200.0f)] private float maxRotationSpeed = 90.0f;

    private Formation currentFormation;
    [SerializeField] private Formation formation1;
    [SerializeField] private Formation formation2;
    [SerializeField] private Formation formation3;
    [SerializeField] private Formation formation4;

    [SerializeField] private Node nodePrefab; // temporary
    private List<Node> allNodes = new List<Node>();



    private void Awake()
    {
        currentFormation = formation1;

        for (int i = 0; i < 10; ++i)
        {
            AddSanmi();
        }
    }


    private void OnEnable()
    {
        playerInputs.OnRotationStop += MakeSanmisStopRotating;

        playerInputs.OnFormation1 += ChangeToFormation1;
        playerInputs.OnFormation2 += ChangeToFormation2;
        playerInputs.OnFormation3 += ChangeToFormation3;
        playerInputs.OnFormation4 += ChangeToFormation4;
    }

    private void OnDisable()
    {
        playerInputs.OnRotationStop -= MakeSanmisStopRotating;

        playerInputs.OnFormation1 -= ChangeToFormation1;
        playerInputs.OnFormation2 -= ChangeToFormation2;
        playerInputs.OnFormation3 -= ChangeToFormation3;
        playerInputs.OnFormation4 -= ChangeToFormation4;
    }

    void Update()
    {
        sanmisRootTransform.Rotate(Vector3.up, maxRotationSpeed * playerInputs.rotateDirection * Time.deltaTime);
    }


    private void MakeSanmisStopRotating()
    {
        Debug.Log("TODO MakeSanmisStopRotating Animation");
    }

    private void ChangeToFormation1()
    {
        Debug.Log("TODO Formation 1");
    }

    private void ChangeToFormation2()
    {
        Debug.Log("TODO Formation 2");
    }

    private void ChangeToFormation3()
    {
        Debug.Log("TODO Formation 3");
    }

    private void ChangeToFormation4()
    {
        Debug.Log("TODO Formation 4");
    }



    private void AddSanmi()
    {
        Node newSanmiNode = Instantiate(nodePrefab, transform);
        newSanmiNode.index = allNodes.Count;

        allNodes.Add(newSanmiNode);

        currentFormation.ArrangeNewNode(newSanmiNode);
    }

}
