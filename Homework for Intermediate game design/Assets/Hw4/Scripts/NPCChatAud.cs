using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChatAud : MonoBehaviour
{
    public Transform p1pos;
    private Transform NPCpos;
    private AudioSource aud;
    public AudioClip chat;
    private bool chatAud = true;
    private float audT;
    // Start is called before the first frame update
    void Start()
    {
        NPCpos = GetComponent<Transform>();
        aud = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        audT++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(NPCpos.transform.position, p1pos.transform.position) < 4)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (audT > 0.5 * 50 && chatAud == true)
                {
                    aud.PlayOneShot(chat);
                    audT = 0;
                    chatAud = false;
                }
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
        {
            chatAud = true;
        }
    }
}
