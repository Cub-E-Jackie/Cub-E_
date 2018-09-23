using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    public GameObject MenuButton;


    void Update()
    {
        if (SpielerLeben.Instance.lives == 0)
        {
            MenuButton.SetActive(true);
        }
    }

    public void MenuScene()
    {
        //MenuButton.SetActive(true);
        SceneManager.LoadScene("Menu");

    }
}
