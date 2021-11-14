using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public Vector2 RawMoveInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }

    [SerializeField] private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        RawMoveInput = context.ReadValue<Vector2>();
        NormInputX = (int)(RawMoveInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMoveInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            jumpInputStartTime = Time.time;
        }
    }

    public void SetJumpFalse() => JumpInput = false;


    public void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }

    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {

    }

    public void OnAltAttackInput(InputAction.CallbackContext context)
    {

    }
}
