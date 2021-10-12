using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoomTrigger : MonoBehaviour
{
    private BoxCollider2D bc;
    public float camX;
    public float camY;
    public Camera cam;

    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
        {
            cam.transform.position = new Vector3(camX, camY, -10);
        }
        
    }


}
