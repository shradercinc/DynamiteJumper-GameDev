using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class KeyboardKey : MonoBehaviour
{ 
    AudioSource audiosource;
    public AudioClip audioClip;

    public KeyCode keyBoardButton;
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void KeyboardInput()
    {
        audiosource.pitch = Input.GetKey(KeyCode.LeftShift) ? audiosource.pitch = 2.0f : audiosource.pitch = 1.0f;

        if (Input.GetKeyDown(keyBoardButton))
        {
            PlayKey();
        }
    }

    void PlayKey()
    {
        audiosource.PlayOneShot(audioClip);
    }

    private void Update()
    {
        KeyboardInput();
    }
}
