using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Transform p1pos;
    public Transform box;
    public Transform emitter;
    public Rigidbody2D boxrb;
    float setx = 0;
    float sety = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) - Mathf.Abs(p1pos.transform.position.x) < 4 && Mathf.Abs(transform.position.y) - Mathf.Abs(p1pos.transform.position.y) < 5 && box.transform.position.y < -10 && Input.GetKeyDown(KeyCode.E))
        {
            setx = emitter.transform.position.x;
            sety = emitter.transform.position.y;
            box.transform.position = new Vector3(setx,sety,0);
            boxrb.velocity = Vector2.zero;
        }
    }
}
