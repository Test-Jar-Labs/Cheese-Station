using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, PlayerAction.IPlayerActions
{
    public delegate void Look(Vector2 lookDirection);
    public Look LookEvent;

    public delegate void Movement(Vector2 moveDirection);
    public Movement MovementEvent;

    public delegate void Shoot();
    public Shoot ShootEvent;

    private PlayerAction inputActions;

    private void Awake()
    {
        inputActions = new PlayerAction();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.SetCallbacks(this);
    }

    private void OnDisable()
    {
        inputActions.Player.SetCallbacks(null);
        inputActions.Disable();
    }

    public void OnCursorPosition(InputAction.CallbackContext context)
    {
        if (context.valueType == typeof(Vector2))
        {
            Vector2 lookDirection = context.ReadValue<Vector2>();
            LookEvent?.Invoke(lookDirection);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.valueType == typeof(Vector2))
        {
            Vector2 moveDirection = context.ReadValue<Vector2>();
            MovementEvent?.Invoke(moveDirection);
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShootEvent?.Invoke();
        } 

        if (context.canceled)
        {

        }
    }
}
