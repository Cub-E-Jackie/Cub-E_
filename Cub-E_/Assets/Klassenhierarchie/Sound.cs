using UnityEngine.Audio;
using UnityEngine;

// Liste mit Eigenschaften bei AudioManager anzeigen
[System.Serializable]
public class Sound  {

    public string name;

    public AudioClip clip;

    // Slider zum einstellen
    [Range(0f, 1f)]
    public float volume; // Volume
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    // AudioSource gespeichert
    [HideInInspector] // wird nicht angezeigt
    public AudioSource source;

}
