using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioSource Music;

    // Start is called before the first frame update
    void Start()
    {
        // Play Background Music
        Music = this.GetComponent<AudioSource>();
        Music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
