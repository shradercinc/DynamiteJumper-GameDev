using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetZone : MonoBehaviour
{
    public PeggelBall mpb;
    public PeggleShooter mps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == mpb.gameObject)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
