using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBSimpleMove : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speedF = 5.0f;
    public float jumpF = 20.0f;

    private bool isGround;
    private bool canJump = false;

    float moveX = 1.0f;

    //public Rigidbody2D otherCandy;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //candy = otherCandy.GetComponent<Rigidbody2D>();
    }

    void Jump()
    {
        if (!isGround)
            return;
        
        rb.AddForce(Vector2.up * jumpF, ForceMode2D.Impulse);
        canJump = false;
        isGround = false;
        Debug.Log("JUMP!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log(collision.gameObject.name, collision.gameObject);
    }


    void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                canJump = true;
            }
        }

        moveX = Input.GetAxis("Horizontal");
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveX * speedF, rb.velocity.y);
        if (canJump)
        {
            Jump();
        }
    }

    void Update()
    {
        PlayerControl();
    }
}
