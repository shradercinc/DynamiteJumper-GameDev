using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//SceneManager.LoadScene(SceneNameString)

public class DeathBox : MonoBehaviour
{
    public float x = 0.0f;
    public float y = 0.0f;
    private float z = 0.0f;
    private BoxCollider2D bc;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(x, y, z);
            Player.lives--;
        }
    }
}
