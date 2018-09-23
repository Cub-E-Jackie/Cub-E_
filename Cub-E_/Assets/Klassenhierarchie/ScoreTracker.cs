using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{

    private int score;
    // um auf die var score zugreifen zu koennen in destroyByContact
    public static ScoreTracker Instance;
    //werte an textfelder abzugeben
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;

    // setten der Punkte, mit Playprefs alte score mit neuer verglichen -> wenn groesser in highscore gespeuchert und ausgegeben
    //hoechster heighscore bleibt auch bei playbeenden erhalten
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            ScoreText.text = "Score:" + score.ToString();

            if (PlayerPrefs.GetInt("HighScore") < score)
            {

                PlayerPrefs.SetInt("HighScore", score);
                HighScoreText.text = "Highscore:" + score.ToString();
            }
        }
    }

    void Awake()
    {

        Instance = this;

        if (!PlayerPrefs.HasKey("HighScore"))
        {

            PlayerPrefs.SetInt("HighScore", 0);

        }

        ScoreText.text = "Score:0";
        HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

    }

}