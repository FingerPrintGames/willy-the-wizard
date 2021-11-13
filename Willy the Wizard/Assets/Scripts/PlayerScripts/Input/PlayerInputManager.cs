using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private Vector2 moveInput;
    
    public void OnMovementInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
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
