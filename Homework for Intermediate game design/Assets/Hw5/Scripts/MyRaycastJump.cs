using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MyRaycastJump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float JumpS = 5.0f;
    [SerializeField]
    float MoveS = 5.0f;
    float MoveX = 1;
    bool isGrounded = false;
    bool canJump = false;

    public float rayCastDistance = 3.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void playerControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
        MoveX = Input.GetAxis("Horizontal");
        CheckGrounded();
    }

    void CheckGrounded()
    {
        RaycastHit2D groundedRay = Physics2D.Raycast(transform.position,Vector2.down, rayCastDistance);
        if (groundedRay.collider != null && groundedRay.collider.GetComponent<JumpObject>())
        {
            isGrounded = true;
        }
        else 
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
        if (!isGrounded)
        {
            return;
        }
        rb.AddForce(Vector2.up * JumpS, ForceMode2D.Impulse);
        isGrounded = true;
    }

    public void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * rayCastDistance, Color.yellow);
    }

    private void FixedUpdate()
    {
        playerControls();
        rb.velocity = new Vector2(MoveX * MoveS, rb.velocity.y);
        if (canJump == true)
        {
            canJump = false;
            Jump();
        }
    }


    private void Update()
    {

    }
}
