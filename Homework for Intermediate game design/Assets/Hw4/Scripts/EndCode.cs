using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndCode : MonoBehaviour
{
    public TMP_Text endTxt;

    // Start is called before the first frame update
    void Start()
    {
        endTxt.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Floor"))
        {
            endTxt.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
