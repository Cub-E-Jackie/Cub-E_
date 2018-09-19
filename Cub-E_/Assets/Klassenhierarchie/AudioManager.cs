using UnityEngine.Audio;
using System; // zum Sound finden
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds; // fuer die gespeicherten Sounds

    // damit keine zwei AudioManager entstehen 
    public static AudioManager instance;

    // aehnlich start nur vorher noch
    void Awake()
    {

        // testen, ob nur eine instance vorhanden 
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return; 
        }

        DontDestroyOnLoad(gameObject); // wird nicht neu geladen, wenn die Szene gewechselt wird

        // loop
        foreach (Sound s in sounds)
        {
            // nur auf dem derzeitigen Objekt, einfacher
            s.source = gameObject.AddComponent<AudioSource>();
            // wird kopiert zum Anfang
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme"); // Hauptmelodie von Anfang an;
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // gesuchter Sound wird in Sound s gespeichert
        // NullReference wird getestet
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found"); // Warnung, dass der geusnchte Sound nicht gefunden wurde
            return; // dann passiert nichts, obwohl kein Sound gefunden wurde
        }
        s.source.Play();
    }

    // bei Kollision Beispiel:
    // FindObjectOfType<AudioManager>().Play("SoundName");

    // fuer mehrere Szenen, AudioManager als Prefab erstellen und dann in die andere Szene einfügen
    // Musik wird dabei aber abgeschnitten
}
