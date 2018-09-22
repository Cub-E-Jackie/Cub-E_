using UnityEngine;
using System;

public class VolumeSlider : MonoBehaviour
{

    // Referenz zum Audio Source
    private AudioSource audioSrc;

    // Wert, der durch den Slider angepasst wird
    private float musicVolume = 1f;


    void Start()
    {

        //Zuordnung von Audio Source zur besseren Kontrolle
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

        // musicVolume wird zum volume von Audio Source gleichgesetzt
        audioSrc.volume = musicVolume;
    }

    // diese Methode wird vom Slider aufgerufen
    // uebernimmt vol-Wert und setzt ihn als musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}