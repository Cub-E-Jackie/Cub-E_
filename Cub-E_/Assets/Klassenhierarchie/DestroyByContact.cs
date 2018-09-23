using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;



public class DestroyByContact : MonoBehaviour
{
    //
    private int eScore;
    public TextMeshProUGUI scoreAnzeige;


    void Start()
    {
        eScore = 0;

    }

    // wenn TriggerObject(Player) mit Object welches mir "Child" getaggt ist, wird eScore 5 Punkte zuaddiert
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Child"))
        {
            FindObjectOfType<AudioManager>().Play("Duck");

            other.gameObject.SetActive(false);
            eScore += 5;
            //Score aus ScoreTracker den jetzigen Wert wiedergeben 
            ScoreTracker.Instance.Score = eScore;

        }

    }

}