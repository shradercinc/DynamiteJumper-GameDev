using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySimpleRB : MonoBehaviour
{
    Rigidbody2D rb;
    bool moveleft;
    bool moveright;
    public float power = 20.0f;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (moveleft == true)
        {
            rb.AddForce(Vector2.left * power);
        }   
        if (moveright)
            rb.AddForce(Vector2.right * power);
        //rb.AddForce(new Vector2(-1.0f,0.0f)); same as above, adds acceleration
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveleft = true;
        }
        else
        {
            moveleft = false;
        }
        moveright = Input.GetKey(KeyCode.RightArrow);
    }
}
