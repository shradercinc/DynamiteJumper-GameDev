using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Transform p1pos;
    public Transform box;
    public Transform emitter;
    public Rigidbody2D boxrb;
    private Transform pos;
    float setx = 0;
    float sety = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(pos.transform.position, p1pos.transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                setx = emitter.transform.position.x;
                sety = emitter.transform.position.y;
                box.transform.position = new Vector3(setx, sety, 0);
                boxrb.velocity = Vector2.zero;
            }

        }
    }
}
