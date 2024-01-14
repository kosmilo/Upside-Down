using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    public event Action OnJumpTriggered;
    private InputManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;

        DontDestroyOnLoad(gameObject);


        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Jump.performed += JumpPerformed;
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        OnJumpTriggered?.Invoke();
    }

    public float GetMovementDirection()
    {
        float inputDir = playerInputActions.Player.Move.ReadValue<float>();

        return inputDir;
    }
}
