using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigButton : MonoBehaviour
{
    public Transform bridge;
    bool extend = false;
    public float bridgeS = 7.5f;
    public float bridgeMin = 0;
    public float bridgeMax = 4.6f;
    public float bridgeY = -4.5f;
    // Start is called before the first frame update
    void Start()
    {
        bridge.transform.position = new Vector3(bridgeMin, bridgeY, 3);
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
        if (extend == true && bridge.transform.position.x < bridgeMax)
        {
            bridge.transform.Translate(Vector2.right * Time.deltaTime * bridgeS);
        }
        else if (extend == true && bridge.transform.position.x >= bridgeMax)
        {
            bridge.transform.position = new Vector3(bridgeMax,bridgeY,3.0f);
        }
        if (extend == false && bridge.transform.position.x > bridgeMin)
        {
            bridge.transform.Translate(Vector2.left * Time.deltaTime * bridgeS);
        }
        else if (extend == false && bridge.transform.position.x <= bridgeMin)
        {
            bridge.transform.position = new Vector3(bridgeMin, bridgeY, 3.0f);
        }

    }
}
