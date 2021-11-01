using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigButtonNeg : MonoBehaviour
{
    public Transform bridge;
    private AudioSource aud;
    public AudioClip click;
    bool extendAud = false;
    bool extend = false;
    public float bridgeS = 7.5f;
    public float bridgeMin = -13.2f;
    public float bridgeMax = -27.9f;
    public float bridgeY = 36.25f;
    // Start is called before the first frame update
    void Start()
    {
        bridge.position = new Vector3(bridgeMin,bridgeY,3);
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Floor"))
        {
            extend = true;
            if (extendAud == false)
            {
                extendAud = true;
                aud.PlayOneShot(click);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        extend = false;
        if (extendAud == true)
        {
            extendAud = false;
            aud.PlayOneShot(click);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (extend == true)
        {
            Debug.Log("Extended");
        }
        if (extend == true && bridge.transform.position.x > bridgeMax)
        {
            bridge.transform.Translate(Vector2.left * Time.deltaTime * bridgeS);
        }
        else if (extend == true && bridge.transform.position.x <= bridgeMax)
        {
            bridge.transform.position = new Vector3(bridgeMax, bridgeY, 3.0f);
        }
        if (extend == false && bridge.transform.position.x < bridgeMin)
        {
            bridge.transform.Translate(Vector2.right * Time.deltaTime * bridgeS);
        }
        else if (extend == false && bridge.transform.position.x >= bridgeMin)
        {
            bridge.transform.position = new Vector3(bridgeMin, bridgeY, 3.0f);
        }

    }
}