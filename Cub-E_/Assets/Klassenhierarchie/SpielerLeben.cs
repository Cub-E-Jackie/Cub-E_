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




    void Start()
    {
        lives = 100;
        HighScore.text = "";
        SubLives();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Feind"))
        {
            other.gameObject.SetActive(false);
            lives -= 1;
            SubLives();
        }
        FindObjectOfType<AudioManager>().Play("Collision");
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


