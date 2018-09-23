using UnityEngine.Audio;
using System; // zum Sound finden
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // fuer die gespeicherten Sounds
    public Sound[] sounds; 

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

        // wird nicht neu geladen, wenn die Szene gewechselt wird
        DontDestroyOnLoad(gameObject);

        // loop
        // Anweisungen für jedes Element in einer Instanz des Typs
        foreach (Sound s in sounds)
        {
            // nur auf dem derzeitigen Objekt
            s.source = gameObject.AddComponent<AudioSource>();
            // wird kopiert zum Anfang
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

			//s.audioMixer.SetFloat("Volume", s.volume);
        }
    }

    private void Start()
    {
        // Hauptmelodie von Anfang an;
        Play("Theme"); 
    }


    public void Play(string name)
    {
        // gesuchter Sound wird in Sound s gespeichert
        Sound s = Array.Find(sounds, sound => sound.name == name); 

        // NullReference wird getestet
        if (s == null)
        {
            // Warnung, dass der geusnchte Sound nicht gefunden wurde
            Debug.LogWarning("Sound: " + name + " not found");
            // dann passiert nichts, obwohl kein Sound gefunden wurde
            return; 
        }
        s.source.Play();
    }

    // bei Kollision Beispiel:
    // FindObjectOfType<AudioManager>().Play("SoundName");

    // fuer mehrere Szenen, AudioManager als Prefab erstellen und dann in die andere Szene einfügen
    // Musik wird dabei aber abgeschnitten
}
