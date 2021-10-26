using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Transform PlPos;

    public static int lives = 5;

    public GameObject dynamite;

    public float speed = 5.0f;
    float moveX = 1.0f;
    public float jumpSpeed = 8.5f;

    bool canJump = false;
    private float DeathTimer = 0.0f;
    public static bool canExp = false;
    public static int numBoom = 0;

    public float detTM = 5 * 50;
    private float detTime = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        PlPos = GetComponent<Transform>();

    }
    void Start()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Box")) && PlPos.transform.position.y > (collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y - 0.5))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Wheel"))
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DynoBox"))
        {
            canExp = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        if (lives <= 0)
        {
            DeathTimer++;
        }
        if (DeathTimer >= 1.5 * 50)
        {
            SceneManager.LoadScene("Homework4Scene0");
        }
        if (numBoom > 0 && canExp == true)
        {
            detTime++;
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            canJump = false;
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        jump();
        if (canExp == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && Player.numBoom == 1 && detTime > detTM)
            {
                Dynamite.detT = Dynamite.detM + 5;
                //Debug.Log("EXPLODE");
            }
            if (Input.GetKeyDown(KeyCode.Q) && Player.numBoom == 0)
            {
                numBoom = 1;
                Object.Instantiate(dynamite, new Vector3(PlPos.transform.position.x, PlPos.transform.position.y, -2), dynamite.transform.rotation);
                detTime = 0;
                Debug.Log(detTime);
                Dynamite.detT = 0;
            }

        }
  
    }
}
