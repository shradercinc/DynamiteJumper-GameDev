using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{
    private BoxCollider2D bc;
    public int Points = 0;


    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("A Collision has happened!", gameObject);

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("A Collision has ended"); 
    }
}

//collision.gameObject.SetActive(false);
//private void OnCollisionEnter2D(Collision2D collision)
//^^ is for when an object isn't a trigger collider 