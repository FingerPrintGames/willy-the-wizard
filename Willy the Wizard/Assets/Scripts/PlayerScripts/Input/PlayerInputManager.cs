using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public Vector2 RawMoveInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    
    public void OnMovementInput(InputAction.CallbackContext context)
    {
        RawMoveInput = context.ReadValue<Vector2>();
        NormInputX = (int)(RawMoveInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMoveInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Jump was pressed.");
        if (context.performed)
            Debug.Log("Jump is being held.");
        if (context.canceled)
            Debug.Log("Jump was let go.");
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {

    }

    public void OnAltAttackInput(InputAction.CallbackContext context)
    {

    }
}
