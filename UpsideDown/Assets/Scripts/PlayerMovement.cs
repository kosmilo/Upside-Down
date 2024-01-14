using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float jumpForce = 3f;

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
        inputManager.OnJumpTriggered += Jump;
    }

    private void OnDisable()
    {
        inputManager.OnJumpTriggered -= Jump;
    }


    // Update is called once per frame (fixed cus physics)
    void Update()
    {
        transform.position += new Vector3(inputManager.GetMovementDirection() * Time.deltaTime * moveSpeed, 0, 0);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, rb.gravityScale * .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    public void GravitySwitch()
    {
        Debug.Log("Gravity Switched");
        rb.gravityScale *= -1;
        jumpForce *= -1;
    }
}
