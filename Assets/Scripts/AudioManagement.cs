using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagement : MonoBehaviour
{
    // Background Music
    public AudioSource Music;
    public Slider MusicSlider;
    public Text MusicText;
    
    // Sound Effects
    public AudioSource CannonFireSound;
    public AudioSource CannonballHitSound;
    public Slider SoundSlider;
    public Text SoundText;
    private float soundVolume;

    void Start()
    {
        // Play Background Music
        Music.Play();
        soundVolume = 1;
    }

    void Update()
    {
        // Update Music Volume
        ChangeMusicVolume(MusicSlider.value);
        MusicText.text = (MusicSlider.value).ToString();

        // Update Sound Volume
        soundVolume = (float)(SoundSlider.value / 100);
        SoundText.text = (SoundSlider.value).ToString();
    }

    //Play Sounds
    public void PlayCannonFireSound()
    {
        CannonFireSound.PlayOneShot(CannonFireSound.clip, soundVolume);
    }
    public void PlayCannonballHitSound()
    {
        CannonballHitSound.PlayOneShot(CannonballHitSound.clip, soundVolume);
    }

    // Volume Management
    void ChangeMusicVolume(float sliderValue)
    {
        Music.volume = (float)(sliderValue / 100);
    } 
}
