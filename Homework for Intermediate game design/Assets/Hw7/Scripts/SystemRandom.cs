using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemRandom : MonoBehaviour
{

    public GameObject block;
    public int seed = 0;
    System.Random r;


    // Start is called before the first frame update
    void Start()
    {
        r = new System.Random();
    }

    void spawnBlockObject()
    {
        float x = (float)(r.NextDouble() * (8.0f - (-8.0f)) + (-8.0f));
        float y = (float)(r.NextDouble() * (5.0f - (-5.0f)) + (-5.0f));
        GameObject b = Instantiate(block, new Vector3(x, y, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
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
