using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 9f;
    [SerializeField] private float jumpForce = 9f;
    [SerializeField] private float jumpTime = 0.1f;
    [SerializeField] private float jumpTimer;
    private bool isJumping = false;
    private float xVelocity;
    private float yVelocity;

    private InputManager inputManager;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask platformsLayerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        inputManager = FindObjectOfType<InputManager>();
        inputManager.OnJumpTriggered += StartJump;
        inputManager.OnJumpCanceled += StopJump;
    }

    private void OnDisable()
    {
        inputManager.OnJumpTriggered -= StartJump;
    }

    private void Update()
    {
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= jumpTime)
            {
                StopJump();
            }
        }
    }

    void FixedUpdate()
    {
        Move();

        yVelocity = isJumping ? jumpForce * Mathf.Clamp(rb.gravityScale, -1, 1) : rb.velocity.y;

        rb.velocity = new Vector3(xVelocity, yVelocity, 0);
    }

    private void Move()
    {
        float moveDir = inputManager.GetMovementDirection();
        xVelocity = Mathf.Lerp(xVelocity, moveDir * moveSpeed, 0.3f);
    }

    private void StartJump()
    {
        if (IsGrounded())
        {
            isJumping = true;
            jumpTimer = 0f;
        }
    }

    private void StopJump()
    {
        if (isJumping)
        {
            isJumping = false;
            yVelocity = 0;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.up * -rb.gravityScale, 0.05f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
}
