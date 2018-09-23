using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;



public class DestroyByContact : MonoBehaviour
{

    private int eScore;
    public TextMeshProUGUI scoreAnzeige;


    void Start()
    {
        eScore = 0;
        //AddScore();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Child"))
        {
            FindObjectOfType<AudioManager>().Play("Duck");

            other.gameObject.SetActive(false);
            eScore += 5;
            ScoreTracker.Instance.Score = eScore;
            //AddScore();

        }

        


    }

    public void AddScore()
    {
        //scoreAnzeige.text = "Score:" + eScore.ToString();
    }

}