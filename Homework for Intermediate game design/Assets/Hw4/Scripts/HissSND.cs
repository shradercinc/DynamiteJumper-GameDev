using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HissSND : MonoBehaviour
{

    private void Awake()
    {
    }

    private void Update()
    {
        if (Player.expAudio == true)
        {
            Destroy(gameObject);
        }
    }
}
