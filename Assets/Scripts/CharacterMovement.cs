using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputs playerInputs;

    [SerializeField] private Transform rootTransform;
    [SerializeField] Rigidbody rb;
    [SerializeField] float maxMoveSpeed = 20.0f;
    [SerializeField] float maxMoveAcceleration = 200.0f;

    [SerializeField] float maxLookRotationSpeed = 300.0f;
    

    private Vector3 moveDirection;



    private void OnEnable()
    {
        //playerInputs.OnMoveStart += () => { Debug.Log("OnMoveStart"); };
        playerInputs.OnMoveStop += StopMovement;
    }

    private void OnDisable()
    {
        //playerInputs.OnMoveStart -= () => { Debug.Log("OnMoveStart"); };
        playerInputs.OnMoveStop -= StopMovement;
    }


    private void Update()
    {
        ClearState();

        moveDirection.x = playerInputs.moveDirection.x;
        moveDirection.z = playerInputs.moveDirection.y;

        if (moveDirection.sqrMagnitude > 0.0f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rootTransform.rotation = Quaternion.RotateTowards(rootTransform.rotation, toRotation, maxLookRotationSpeed * Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * maxMoveAcceleration, ForceMode.Acceleration);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxMoveSpeed);
    }


    private void ClearState()
    {
        moveDirection = Vector3.zero;
    }

    private void StopMovement()
    {
        rb.AddForce(-rb.velocity * 0.75f, ForceMode.Impulse);
    }



}
