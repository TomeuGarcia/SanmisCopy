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

    [SerializeField] float maxLookAtRotationSpeed = 300.0f;
    

    private Vector3 moveDirection;
    private bool desiredJump = false;

    private bool stopMoving = false;



    private void OnEnable()
    {
        //playerInputs.OnMoveStart += () => { Debug.Log("OnMoveStart"); };
        playerInputs.OnMoveStop += StopMovement;
        playerInputs.OnJumpStart += () => desiredJump = true;
        playerInputs.OnJumpStop += () => desiredJump = false;
    }

    private void OnDisable()
    {
        //playerInputs.OnMoveStart -= () => { Debug.Log("OnMoveStart"); };
        playerInputs.OnMoveStop -= StopMovement;
        playerInputs.OnJumpStart -= () => desiredJump = true;
        playerInputs.OnJumpStop -= () => desiredJump = false;
    }


    private void Update()
    {
        if (stopMoving) return;

        ClearState();

        moveDirection.x = playerInputs.moveDirection.x;
        moveDirection.z = playerInputs.moveDirection.y;

        if (moveDirection.sqrMagnitude > 0.0f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rootTransform.rotation = Quaternion.RotateTowards(rootTransform.rotation, toRotation, maxLookAtRotationSpeed * Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        if (stopMoving) return;

        rb.AddForce(moveDirection * maxMoveAcceleration, ForceMode.Acceleration);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxMoveSpeed);

        //if (CheckJump())
        //{
        //    Jump();
        //}
    }


    private void ClearState()
    {
        moveDirection = Vector3.zero;
    }

    private void StopMovement()
    {
        rb.AddForce(-rb.velocity * 0.75f, ForceMode.Impulse);
    }

    public void DisableMovement()
    {
        stopMoving = true;
    }

    public void EnableMovement()
    {
        stopMoving = false;

        StopMovement();
    }

    private bool CheckJump()
    {
        return desiredJump;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * 200.0f, ForceMode.Impulse);

        desiredJump = false;
    }



}
