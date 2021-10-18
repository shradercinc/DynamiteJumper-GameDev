using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColdCollect : MonoBehaviour
{
    public Transform P1Pos;
    public string level;
    private Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(pos.transform.position, P1Pos.transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.lives = 5;
                SceneManager.LoadScene(level);
            }
        }
    }
}
