using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpielerLeben : MonoBehaviour
{

    private int lives;
    public TextMeshProUGUI LiveAnzeige;
    public TextMeshProUGUI HighScore;
    DuckMovement zeit;

    private bool collidingWithFeind;
    private bool collidingWithPlayer;
    public Animator anim;


    void Start()
    {
        lives = 100;
        HighScore.text = "";
        SubLives();

    }

    // doppelter Trigger für Animation und Leben
    // Collider muss wieder auf false gestellt werden
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Feind"))
        {
            FindObjectOfType<AudioManager>().Play("Collision");

            collidingWithFeind = true;
            lives -= 1;
            SubLives();
        }
        else if (col.CompareTag("Player"))
        {
            collidingWithPlayer = true;
            anim.enabled = true;
            Destroy(gameObject);
        }
    }

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


    public void SubLives()
    {
        LiveAnzeige.text = "Lives:" + lives.ToString();
        if (lives == 0)
        {
            HighScore.text = "Highscore\n" + ScoreTracker.Instance.Score;

            zeit = GameObject.Find("Player").GetComponent<DuckMovement>();
            zeit.activModus = false;
            Time.timeScale = 0f;
        }
    }
}

