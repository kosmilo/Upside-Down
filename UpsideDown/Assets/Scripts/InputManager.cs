using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInputActions playerInputActions { get; private set; }
    public event Action OnJumpTriggered;
    public event Action OnJumpCanceled;
    public event Action OnPauseTriggered;
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
        playerInputActions.UI.Enable();

        playerInputActions.Player.Jump.performed += JumpPerformed;
        playerInputActions.Player.Jump.canceled += JumpCanceled;
        playerInputActions.UI.PauseGame.performed += PauseGame;
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        OnJumpTriggered?.Invoke();
    }

    public void JumpCanceled(InputAction.CallbackContext context)
    {
        OnJumpCanceled?.Invoke();
    }

    public float GetMovementDirection()
    {
        float inputDir = playerInputActions.Player.Move.ReadValue<float>();

        return inputDir;
    }

    public void PauseGame(InputAction.CallbackContext context) {
        OnPauseTriggered?.Invoke();
    }
}
