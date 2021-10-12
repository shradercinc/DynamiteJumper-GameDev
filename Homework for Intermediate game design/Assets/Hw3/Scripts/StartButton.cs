using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{     
    public Rigidbody2D rb;
// Start is called before the first frame update

    void Awake()
    {
        rb.Sleep();
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.WakeUp();
        }
    }
}
