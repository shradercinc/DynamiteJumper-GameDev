using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigButton : MonoBehaviour
{
    public Transform bridge;
    bool extend = false;
    public float bridgeS = 7.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!collision.CompareTag("Floor"))
        {
            extend = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        extend = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (extend == true)
        {
            Debug.Log("Extended");
        }
        if (extend == true && bridge.transform.position.x < 4.6)
        {
            bridge.transform.Translate(Vector2.right * Time.deltaTime * bridgeS);
        }
        else if (extend == true && bridge.transform.position.x >= 4.6)
        {
            bridge.transform.position = new Vector3(4.6f,-4.5f,111.0f);
        }
        if (extend == false && bridge.transform.position.x > 0)
        {
            bridge.transform.Translate(Vector2.left * Time.deltaTime * bridgeS);
        }
        else if (extend == false && bridge.transform.position.x <= 0)
        {
            bridge.transform.position = new Vector3(0.0f, -4.5f, 111.0f);
        }

    }
}
