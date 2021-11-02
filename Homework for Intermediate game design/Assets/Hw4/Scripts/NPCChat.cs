using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCChat : MonoBehaviour
{
    public Transform p1pos;
    public Transform NPCpos;
    public Sprite F1;
    public Sprite F2;
    public SpriteRenderer NPCspr;
    public float timer;
    private TMP_Text myText;
    private bool active = false;


    // Start is called before the first frame update
    void Awake()
    {
        myText = GetComponent<TMP_Text>();
        myText.enabled = false;

    }

    private void FixedUpdate()
    {
        timer++;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0.75 * 50)
        {
            NPCspr.sprite = F1;
        }
        if (timer > 0.75 * 50) 
        {
            NPCspr.sprite = F2;
        }
        if (timer > 1.5 * 50)
        {
            timer = 0;
        }



        if (active == true)
        {
            myText.enabled = true;
        } else 
        {
            myText.enabled = false;    
        }


        //if (Mathf.Abs(NPCpos.transform.position.x) - Mathf.Abs(p1pos.transform.position.x) < 4 && Mathf.Abs(NPCpos.transform.position.y) - Mathf.Abs(p1pos.transform.position.y) < 5)
        if(Vector2.Distance(NPCpos.transform.position, p1pos.transform.position) < 4)       
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                active = true;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
        {
            active = false;

        }
    }
}
