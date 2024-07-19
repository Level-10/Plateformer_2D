using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;
using UnityEngine.InputSystem;

public class InputComponent : ParentComponent
{
    [SerializeField] Inputs controls = null;
    [SerializeField] InputAction inputMove = null;
    [SerializeField] InputAction inputJump = null;

    public InputAction InputMove => inputMove;
    public InputAction InputJump => inputJump;

    protected override void Awake()
    {
        base.Awake();
        controls = new Inputs();
    }

    private void OnEnable()
    {
        inputMove = controls.GroundMovements.Movement;
        inputJump = controls.GroundMovements.Jump;
        inputMove.Enable();
        inputJump.Enable();

        inputJump.performed += playerRef.MovementComponent.Jump;
    }

}
