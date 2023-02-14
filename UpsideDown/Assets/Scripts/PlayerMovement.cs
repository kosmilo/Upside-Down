using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float jumpForce = 15f;
    public Rigidbody2D rb2d;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask platformsLayerMask;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame (fixed cus physics)
    void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, 0);
    }

    private void Update()
    {
        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                Debug.Log("Jump");
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, rb2d.gravityScale * .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    public void GravitySwitch()
    {
        Debug.Log("Gravity Switched");
        rb2d.gravityScale *= -1;
        jumpForce *= -1;
    }
}
