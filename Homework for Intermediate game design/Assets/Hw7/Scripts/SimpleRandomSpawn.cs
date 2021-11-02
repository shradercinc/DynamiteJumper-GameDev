using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleRandomSpawn : MonoBehaviour
{
    public GameObject block;
    public int seed = 0;
    System.Random r;

    private void Start()
    {
        //Random.InitState(seed);
    }

    void spawnBlockObject()
    {
        float x = Random.Range(-8.0f, 8.0f);
        float y = Random.Range(-5.0f, 5.0f);
        GameObject b = Instantiate(block, new Vector3(x, y, 0.0f), Quaternion.identity);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnBlockObject();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
