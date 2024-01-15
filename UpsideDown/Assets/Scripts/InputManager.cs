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
    public event Action OnJumpCanceled;
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
        playerInputActions.Player.Jump.canceled += JumpCanceled;
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Jump performed");
        OnJumpTriggered?.Invoke();
    }

    public void JumpCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Jump canceled");
        OnJumpCanceled?.Invoke();
    }

    public float GetMovementDirection()
    {
        float inputDir = playerInputActions.Player.Move.ReadValue<float>();

        return inputDir;
    }
}
