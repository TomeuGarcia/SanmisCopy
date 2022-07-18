using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanmiCollider : MonoBehaviour
{
    private Node node;
    private SanmiMovement sanmiMovement;
    public SanmisController sanmisController;

    [SerializeField] private Collider collider;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private float floorRaycastDistance = 0.5f;
    private bool isStandingOnFloor = true;

    [SerializeField] float lifetimeNoFloor = 1.0f;


    private void OnEnable()
    {
        sanmiMovement.OnFirstArriveAtPosition += EnableCollisions;
    }

    private void OnDisable()
    {
        sanmiMovement.OnFirstArriveAtPosition -= EnableCollisions;
    }

    private void Update()
    {
        EvaluateStandingOnFloor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }


    public void Init(Node node, SanmiMovement sanmiMovement)
    {
        this.node = node;
        this.sanmiMovement = sanmiMovement;

        DisableCollisions();
    }


    private void EnableCollisions()
    {
        collider.enabled = true;
    }

    private void DisableCollisions()
    {
        collider.enabled = false;
    }


    private void Die()
    {
        sanmisController.KillSanmiWithIndex(node.index);
        Destroy(transform.parent.gameObject);
    }

    private void EvaluateStandingOnFloor()
    {
        if (Physics.Raycast(transform.position, Vector3.down, floorRaycastDistance, raycastLayerMask, QueryTriggerInteraction.Ignore))
        {
            if (!isStandingOnFloor)
            {
                isStandingOnFloor = true;
                StopCoroutine("NoFloorDeath");
            }
        }
        else
        {
            if (isStandingOnFloor)
            {
                isStandingOnFloor = false;
                StartCoroutine("NoFloorDeath");
            }
        }
    }

    IEnumerator NoFloorDeath()
    {
        yield return new WaitForSeconds(lifetimeNoFloor);

        Die();
    }

}
