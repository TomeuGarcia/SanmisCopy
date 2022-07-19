using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanmisController : MonoBehaviour
{
    [SerializeField] PlayerInputs playerInputs;

    [SerializeField] private Transform sanmisRootTransform;
    [SerializeField] private Transform sanmisSpawnTransform;
    [SerializeField, Range(0.0f, 200.0f)] private float maxRotationSpeed = 90.0f;

    private Formation currentFormation;
    [SerializeField] private Formation formation1;
    [SerializeField] private Formation formation2;
    [SerializeField] private Formation formation3;
    [SerializeField] private Formation formation4;

    [SerializeField] private GameObject sanmiPrefab; // temporary
    private List<Node> allNodes = new List<Node>();


    private void Awake()
    {
        currentFormation = formation1;
    }


    private void OnEnable()
    {
        playerInputs.OnRotationStop += MakeSanmisStopRotating;

        playerInputs.OnFormation1 += ChangeToFormation1;
        playerInputs.OnFormation2 += ChangeToFormation2;
        playerInputs.OnFormation3 += ChangeToFormation3;
        playerInputs.OnFormation4 += ChangeToFormation4;

        playerInputs.OnCancel += KillRandomSanmi;
    }

    private void OnDisable()
    {
        playerInputs.OnRotationStop -= MakeSanmisStopRotating;

        playerInputs.OnFormation1 -= ChangeToFormation1;
        playerInputs.OnFormation2 -= ChangeToFormation2;
        playerInputs.OnFormation3 -= ChangeToFormation3;
        playerInputs.OnFormation4 -= ChangeToFormation4;

        playerInputs.OnCancel -= KillRandomSanmi;
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
        if (currentFormation != formation1)
        {
            currentFormation = formation1;
            ArrangeCurrentFormation();
        }
    }

    private void ChangeToFormation2()
    {
        if (currentFormation != formation2)
        {
            currentFormation = formation2;
            ArrangeCurrentFormation();
        }
    }

    private void ChangeToFormation3()
    {
        if (currentFormation != formation3)
        {
            currentFormation = formation3;
            ArrangeCurrentFormation();
        }
    }

    private void ChangeToFormation4()
    {
        if (currentFormation != formation4)
        {
            currentFormation = formation4;
            ArrangeCurrentFormation();
        }
    }


    private void ArrangeCurrentFormation()
    {
        currentFormation.ArrangeAll(allNodes);
    }


    public Transform GetSanmisSpawnTransform()
    {
        return sanmisSpawnTransform;
    }


    public void AddNewSanmi(Sanmi newSanmi)
    {
        newSanmi.node.index = allNodes.Count;
        allNodes.Add(newSanmi.node);
        currentFormation.ArrangeNewNode(newSanmi.node);

        newSanmi.sanmiCollider.sanmisController = this;
    }

    public void KillSanmiWithIndex(int index)
    {

        currentFormation.RemoveNodeWithIndex(index);

        for (int i = allNodes.Count - 1; i >= 0; --i)
        {
            if (allNodes[i].isRemoved)
            {
                allNodes[i].GetsKilled();
                allNodes.RemoveAt(i);
            }
        }

        currentFormation.ArrangeAll(allNodes);
    }

    private void KillRandomSanmi()
    {
        int killedSanmiIndex = Random.Range(0, allNodes.Count);

        KillSanmiWithIndex(killedSanmiIndex);
    }


    public Dictionary<Sanmi.SanmiType, int> GetSanmis()
    {
        Dictionary<Sanmi.SanmiType, int> sanmisByAmount = new Dictionary<Sanmi.SanmiType, int>();
        for (int i = 0; i < (int)Sanmi.SanmiType.COUNT; ++i)
        {
            sanmisByAmount[(Sanmi.SanmiType)i] = 0;
        }

        for (int i = 0; i < allNodes.Count; ++i)
        {
            ++sanmisByAmount[allNodes[i].GetComponentInParent<Sanmi>().sanmiType];
        }

        return sanmisByAmount;
    }

}
