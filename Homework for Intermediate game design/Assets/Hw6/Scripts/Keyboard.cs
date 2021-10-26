using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public float volume;
    public List<KeyboardKey> KeyboardKey = new List<KeyboardKey>();
    public AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audiosource.volume = MusicManager.instance.volume;
        audiosource.pitch = MusicManager.instance.tempo;

        if (Input.GetKeyDown(KeyCode.P))
        {
            audiosource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.O) && !audiosource.isPlaying)
        {
            audiosource.Play();
        }
    }

}
