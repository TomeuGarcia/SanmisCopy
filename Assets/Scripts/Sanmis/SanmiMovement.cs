using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanmiMovement : MonoBehaviour
{
    [SerializeField] Node node;

    private int indexInAttachedNodeChain;
    private NodeChain attachedNodeChain;

    [SerializeField] float maxMoveSpeed = 6.4f;
    [SerializeField] float maxLookAtRotationSpeed = 1200.0f;


    private delegate void MovementFunction();
    private MovementFunction currentMovementFunction;

    public delegate void SanmiMovementAction();
    public SanmiMovementAction OnFirstArriveAtPosition;

    private Vector3 current;
    private Vector3 target;




    private void Awake()
    {
        currentMovementFunction = InitialMoveTowardsTarget;
    }


    private void OnEnable()
    {
        node.OnChainSet += SetAttachedNodeChain;
    }

    private void OnDisable()
    {
        node.OnChainSet -= SetAttachedNodeChain;
    }


    private void Update()
    {
        currentMovementFunction();
    }


    private void SetAttachedNodeChain(int nodeIndexInChain, NodeChain nodeChain)
    {
        indexInAttachedNodeChain = nodeIndexInChain;
        attachedNodeChain = nodeChain;
    }

    private void MoveTowardsTarget()
    {
        current = transform.position;
        target = attachedNodeChain.GetPositionInChain(indexInAttachedNodeChain);

        transform.position = Vector3.MoveTowards(current, target, maxMoveSpeed * Time.deltaTime);

        Vector3 forward = (target - current).normalized;
        if (forward != Vector3.zero)
        {
            Quaternion lookAt = Quaternion.LookRotation(forward, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAt, maxLookAtRotationSpeed * Time.deltaTime);
        }
    }

    private void InitialMoveTowardsTarget()
    {
        MoveTowardsTarget();

        if (Vector3.Distance(current, target) < 0.1f)
        {
            if (OnFirstArriveAtPosition != null) OnFirstArriveAtPosition();
            currentMovementFunction = MoveTowardsTarget;
        }
    }


}
