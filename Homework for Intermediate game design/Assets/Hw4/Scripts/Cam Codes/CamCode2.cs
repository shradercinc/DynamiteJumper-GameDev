using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCode2 : MonoBehaviour
{

    public Transform playerPosition;
    private float x1 = 0;
    private float y1 = 0;

    private float px = 0;
    private float py = 0;
    // Start is called before the first frame update
    void Awake()
    {
        x1 = playerPosition.transform.position.x;
        y1 = playerPosition.transform.position.y;
        px = playerPosition.transform.position.x;
        py = playerPosition.transform.position.y;
        transform.position = new Vector3(x1, y1, -10);
        if (y1 < 0)
        {
            y1 = 0;
        }
    }

    private void FixedUpdate()
    {
        px = playerPosition.transform.position.x;
        py = playerPosition.transform.position.y;
        //                  CAMERA OPERATIONS

        x1 = transform.position.x;
        y1 = transform.position.y;

        if (py < 0)
        {
            //Debug.Log("Player lower than 0");
            transform.position = Vector3.Lerp(new Vector3(x1, y1, -10), new Vector3(px, 0, -10), 0.07f);

        }
        else
        {
            //Debug.Log("Player Higher than 0");
            if (py >= 0)
            {
                transform.position = Vector3.Lerp(new Vector3(x1, y1, -10), new Vector3(px, py, -10), 0.07f);
            }

        }
    }

    // Update is called once per frame


    void Update()
    {

    }
}