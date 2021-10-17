using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Lives : MonoBehaviour
{
    public Transform camt;
    private SpriteRenderer rd;
    private Transform pos;
    public int life;
    private float basex = -7.5f;
    private float basey = 4f;
    private float mod = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<SpriteRenderer>();
        pos = GetComponent<Transform>();

        pos.transform.position = new Vector3(camt.transform.position.x + basex + ((life - 1) * mod), camt.transform.position.y + basey, -9.0f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        pos.transform.position = new Vector3(camt.transform.position.x + basex + ((life - 1) * mod), camt.transform.position.y + basey, -9.0f);
    }

    void Update()
    {
        pos.transform.position = new Vector3(camt.transform.position.x + basex + ((life - 1) * mod), camt.transform.position.y + basey, -9.0f);

        if (Player.lives < life)
        {
            rd.enabled = false;
        }

        if (Player.lives >= life)
        {
            rd.enabled = true;
        }
    }
}
