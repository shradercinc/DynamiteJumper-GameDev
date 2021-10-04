using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeggelBall : MonoBehaviour
{

    Rigidbody2D rb;
    public float forceToAdd = 2.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    void MouseControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.simulated = true;
            transform.parent = null;
            rb.AddForce(transform.right * forceToAdd);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
