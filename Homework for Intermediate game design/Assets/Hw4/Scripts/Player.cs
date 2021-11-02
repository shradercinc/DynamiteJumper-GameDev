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
    private AudioSource aud;

    public static int lives = 5;

    public GameObject dynamite;
    public GameObject hissSND;

    public float speed = 5.0f;
    float moveX = 1.0f;

    public float jumpSpeed = 0.5f;
    public float IjumpSpeed = 2.0f;
    public float JumpBM = 0.1f;
    bool canJump = false;
    bool allowance = false;
    float allowT = 0.0f;
    float JumpBonusT = 0.0f;
    int jumping = 0;

    private float DeathTimer = 0.0f;
    public static bool canExp = false;
    public static int numBoom = 0;

    public float detTM = 0.2f;
    private float detTime = 0;

    private float animT;
    private float JAnimT = 0.4f;

    public static float deathT = 0.0f;

    public Sprite l1;
    public Sprite l2;
    public Sprite l3;

    public Sprite r1;
    public Sprite r2;
    public Sprite r3;

    public Sprite m1;
    public Sprite m2;
    public Sprite m3;

    public Sprite j1;
    public Sprite j2;
    public Sprite j3;

    public AudioClip walk;
    private float walkT = 0;
    public AudioClip jumpSnd;
    public AudioClip explode;
    public static bool expAudio = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        PlPos = GetComponent<Transform>();
        ren = GetComponent<SpriteRenderer>();
        aud = GetComponent<AudioSource>();

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            allowance = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Box")) && PlPos.transform.position.y > (collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y - 0.5))
        {
            canJump = true;
            allowance = false;

        }
        if (collision.gameObject.CompareTag("Wheel"))
        {
            canJump = true;
            allowance = false;

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Box")) && PlPos.transform.position.y > (collision.gameObject.transform.position.y + collision.gameObject.transform.localScale.y - 0.5))
        {
            allowance = false;
        }
        if (collision.gameObject.CompareTag("Wheel"))
        {
            allowance = false;
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

        if (jumping == 1 && JumpBonusT <= 0 && canJump == true)
        {
            aud.PlayOneShot(jumpSnd);
            canJump = false;
            jumping = 2;
            rb.AddForce(Vector2.up * IjumpSpeed, ForceMode2D.Impulse);
            JumpBonusT = JumpBM * 50;
        }
        if (jumping == 2 && JumpBonusT > 0)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        if (lives <= 0)
        {
            DeathTimer++;
        }
        if (DeathTimer >= 1.5 * 50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        detTime++;
        animT++;
        JAnimT++;
        JumpBonusT--;
        walkT++;
        deathT--;

        if (allowance == false)
        {
            allowT = 0;
        }
        else
        {
            allowT++;
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true && allowT < 0.1 * 50)
        {
            jumping = 1;
            JAnimT = 0;
        }
        if (Input.GetKeyUp(KeyCode.Space))    
        {
            jumping = 0;
        }

    }

    void Update()
    {
        //                              ANIMATION CODE
        if (animT > 1 * 50)
        {
            animT = 0;
        }

        if (JAnimT < 0.2f * 50 && (allowT > 0.1 * 50 || canJump == false))
        {
            ren.sprite = j1;
        }
        if (JAnimT > 0.2f * 50 && JAnimT < 0.4f * 50 && (allowT > 0.1 * 50 || canJump == false))
        {
            ren.sprite = j2;
        }
        if (JAnimT > 0.4f * 50 && (allowT > 0.1 * 50 || canJump == false))
        {
            ren.sprite = j3;
        }

        /*
        if ((allowT < 0.1 * 50 && canJump == true) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && walkT > 0.5 * 50)
        {
            if (animT < 0.25f * 50)
            {
                aud.PlayOneShot(walk);
                walkT = 0;
            }
            if (animT > 0.25f * 50 && animT < 0.5f * 50)
            {
                aud.PlayOneShot(walk);
                walkT = 0;
            }
            if (animT > 0.5f * 50 && animT < 0.75f * 50)
            {
                aud.PlayOneShot(walk);
                walkT = 0;
            }
            if (animT > 0.75f * 50)
            {
                aud.PlayOneShot(walk);
                walkT = 0;
            }
        }
        */
        if ((allowT < 0.1 * 50 && canJump == true) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
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
        else if ((allowT < 0.1 * 50 && canJump == true) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
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
        else if (allowT < 0.1 * 50 && canJump == true)
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

        //                              DYNAMITE CODE
        if (canExp == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Button Pressed");
                if (Player.numBoom == 1)
                {
                    Debug.Log("One explosive on screen");
                    if (detTime > (detTM / 5) / 2)
                    {
                        Debug.Log("in time frame");
                        if(Dynamite.detT <= Dynamite.detM)
                        {
                            Dynamite.detT = Dynamite.detM + 5;
                            Debug.Log("EXPLODE");
                            if(expAudio == false)
                            {
                                expAudio = true;
                                aud.PlayOneShot(explode); 
                            }    
                        }
                    }
                }
            }
            if (Dynamite.detT > Dynamite.detM && expAudio == false)
            {
                expAudio = true;
                aud.PlayOneShot(explode);               
            }
            if (Input.GetKeyDown(KeyCode.Q) && Player.numBoom == 0)
            {
                Player.numBoom = 1;
                Object.Instantiate(dynamite, new Vector3(PlPos.transform.position.x, PlPos.transform.position.y, -2), dynamite.transform.rotation);
                Object.Instantiate(hissSND, new Vector3(PlPos.transform.position.x, PlPos.transform.position.y, -2), dynamite.transform.rotation);
                detTime = 0;
                Dynamite.detT = 0;
                expAudio = false;
            }


        }
  
    }
}
