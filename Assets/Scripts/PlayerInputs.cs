using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    
    // Store controls
    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction formation1Action;
    private InputAction formation2Action;
    private InputAction formation3Action;
    private InputAction formation4Action;
    private InputAction restartAction;
    private InputAction cancelAction;


    // Attributes for consumer to read 
    public Vector2 moveDirection { get; private set; }
    public float rotateDirection { get; private set; }

    // Actions invoked for consumer to read
    public delegate void PlayerInputsAction();
    public event PlayerInputsAction OnMoveStart;
    public event PlayerInputsAction OnMoveStop;
    public event PlayerInputsAction OnRotationStop;
    public event PlayerInputsAction OnFormation1;
    public event PlayerInputsAction OnFormation2;
    public event PlayerInputsAction OnFormation3;
    public event PlayerInputsAction OnFormation4;
    public event PlayerInputsAction OnRestart;
    public event PlayerInputsAction OnCancel;



    private void Awake()
    {
        moveAction = playerInput.actions["Move"];
        rotateAction = playerInput.actions["Rotate"];
        formation1Action = playerInput.actions["Formation1"];
        formation2Action = playerInput.actions["Formation2"];
        formation3Action = playerInput.actions["Formation3"];
        formation4Action = playerInput.actions["Formation4"];
        restartAction = playerInput.actions["Restart"];
        cancelAction = playerInput.actions["Cancel"];
    }


    private void OnEnable()
    {
        moveAction.started += _ => { if (OnMoveStart != null) OnMoveStart(); };
        moveAction.canceled += _ => { if (OnMoveStop != null) OnMoveStop(); };

        rotateAction.canceled += _ => { if (OnRotationStop != null) OnRotationStop(); };

        formation1Action.started += _ => { if (OnFormation1 != null) OnFormation1(); };
        formation2Action.started += _ => { if (OnFormation2 != null) OnFormation2(); };
        formation3Action.started += _ => { if (OnFormation3 != null) OnFormation3(); };
        formation4Action.started += _ => { if (OnFormation4 != null) OnFormation4(); };

        restartAction.started += _ => { if (OnRestart != null) OnRestart(); };
        cancelAction.started += _ => { if (OnCancel != null) OnCancel(); };
    }

    private void OnDisable()
    {
        moveAction.started -= _ => { if (OnMoveStart != null) OnMoveStart(); };
        moveAction.canceled -= _ => { if (OnMoveStop != null) OnMoveStop(); };

        rotateAction.canceled -= _ => { if (OnRotationStop != null) OnRotationStop(); };

        formation1Action.started -= _ => { if (OnFormation1 != null) OnFormation1(); };
        formation2Action.started -= _ => { if (OnFormation2 != null) OnFormation2(); };
        formation3Action.started -= _ => { if (OnFormation3 != null) OnFormation3(); };
        formation4Action.started -= _ => { if (OnFormation4 != null) OnFormation4(); };

        restartAction.started -= _ => { if (OnRestart != null) OnRestart(); };
        cancelAction.started -= _ => { if (OnCancel != null) OnCancel(); };
    }


    private void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
        rotateDirection = rotateAction.ReadValue<float>();
    }

}
