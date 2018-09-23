using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpielerLeben : MonoBehaviour
{
    //leben initi
    public int lives;
    //werte an Textfelder abgeben
    public TextMeshProUGUI LiveAnzeige;
    public TextMeshProUGUI HighScore;
    //zugriff auf aktvitaet der funktion
    DuckMovement zeit;
    //zum zugreifen der var lives in restart
    public static SpielerLeben Instance;

    //animation steuern
    private bool collidingWithFeind;
    private bool collidingWithPlayer;
    //aufrufen des animator -> zugriff auf Take
    public Animator anim;


    void Start()
    {
        // player hat 3 leben, highscore platzhalter
        Instance = this;
        lives = 3;
        HighScore.text = "";
        SubLives();

    }

    // doppelter Trigger für Animation und Leben
    // Collider muss wieder auf false gestellt werden
    void OnTriggerEnter(Collider col)
    {
        //wenn Player mit Object, welches mit Feind getaggt ist zusammenstoßt verliert er ein Leben
        if (col.CompareTag("Feind"))
        {
            FindObjectOfType<AudioManager>().Play("Collision");

            collidingWithFeind = true;
            lives -= 1;
            SubLives();
        }
        // wenn Player mit einem Object zusammenstößt welches Animator erhält wir Animation abgespielt
        else if (col.CompareTag("Player"))
        {
            collidingWithPlayer = true;
            anim.enabled = true;
        }
    }

    // Trigger zurüchgesetzt
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Feind"))
        {
            collidingWithFeind = false;
        }
        else if (col.CompareTag("Player"))
        {
            collidingWithPlayer = false;
        }
    }

    // gibt leben an textfels aus, highscore erscheint nach ende des Spieles(lives == 0), bewegung der Ente wird gestoppt
    public void SubLives()
    {
        LiveAnzeige.text = "Lives:" + lives.ToString();
        if (lives == 0)
        {
            HighScore.text = "Highscore\n" + ScoreTracker.Instance.Score;
            // zugriif aus script duckmovement um bewegung zu stoppen
            zeit = GameObject.Find("Player").GetComponent<DuckMovement>();
            zeit.activModus = false;
            Time.timeScale = 0f;
        }
		
    }
}

