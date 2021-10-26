using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Transform PlPos;
    private SpriteRenderer ren;

    public static int lives = 5;

    public GameObject dynamite;

    public float speed = 5.0f;
    float moveX = 1.0f;
    public float jumpSpeed = 8.5f;

    bool canJump = false;
    private float DeathTimer = 0.0f;
    public static bool canExp = false;
    public static int numBoom = 0;

    public float detTM = 0.2f;
    private float detTime = 0;

    private int animT;

    public Sprite l1;
    public Sprite l2;
    public Sprite l3;

    public Sprite r1;
    public Sprite r2;
    public Sprite r3;

    public Sprite m1;
    public Sprite m2;
    public Sprite m3;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        PlPos = GetComponent<Transform>();
        ren = GetComponent<SpriteRenderer>();

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

        detTime++;
        animT++;    
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
        if (animT > 1 * 50)
        {
            animT = 0;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (animT < 0.25f * 50)
            {
                ren.sprite = r1;
            }
            if (animT > 0.25f * 50 && animT < 0.5f * 50)
            {
                ren.sprite = r2;
            }
            if (animT > 0.5f * 50 && animT < 0.75f * 50)
            {
                ren.sprite = r3;
            }
            if (animT > 0.75f * 50)
            {
                ren.sprite = r2;
            }
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (animT < 0.25f * 50)
            {
                ren.sprite = l1;
            }
            if (animT > 0.25f * 50 && animT < 0.5f * 50)
            {
                ren.sprite = l2;
            }
            if (animT > 0.5f * 50 && animT < 0.75f * 50)
            {
                ren.sprite = l3;
            }
            if (animT > 0.75f * 50)
            {
                ren.sprite = l2;
            }
        }
        else
        {
            if (animT < 0.25f * 50)
            {
                ren.sprite = m1;
            }
            if (animT > 0.25f * 50 && animT < 0.5f * 50)
            {
                ren.sprite = m2;
            }
            if (animT > 0.5f * 50 && animT < 0.75f * 50)
            {
                ren.sprite = m3;
            }
            if (animT > 0.75f * 50)
            {
                ren.sprite = m2;
            }
        }


        moveX = Input.GetAxis("Horizontal");
        jump();
        if (canExp == true)
        {
            Debug.Log("dettime = " + detTime);
            Debug.Log("Min = " + detTM);
            //Debug.Log("numBoom = " + numBoom);
            //Debug.Log("det time = " + detTime);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Button Pressed");
                if (Player.numBoom == 1)
                {
                    Debug.Log("NumBoom = 1");
                    if (detTime > (detTM / 5) / 2)
                    {
                        Debug.Log("in time frame");
                        if(Dynamite.detT <= Dynamite.detM)
                        {
                            Dynamite.detT = Dynamite.detM + 5;
                            Debug.Log("EXPLODE");
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q) && Player.numBoom == 0)
            {
                Player.numBoom = 1;
                Object.Instantiate(dynamite, new Vector3(PlPos.transform.position.x, PlPos.transform.position.y, -2), dynamite.transform.rotation);
                detTime = 0;
                Debug.Log(detTime);
                Dynamite.detT = 0;
            }

        }
  
    }
}
