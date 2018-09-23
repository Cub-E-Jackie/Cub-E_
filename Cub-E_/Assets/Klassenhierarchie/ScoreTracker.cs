using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{

    private int score;
    public static ScoreTracker Instance;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;


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