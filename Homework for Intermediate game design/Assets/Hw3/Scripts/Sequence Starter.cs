using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceStarter : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update

    void Awake()
    {
        rb.Sleep();
    }
    
    void Start()
    {
        
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
