using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// aufrufen der Scene Menu in SampleScene
public class Restart : MonoBehaviour {

    public GameObject MenuButton;


    void Update()
    {
        // MenuButton wird nur angezigt wenn man gestorben ist
        if (SpielerLeben.Instance.lives == 0)
        {
            //Sichbarkeit aktiviert
            MenuButton.SetActive(true);
        }
    }

    //MenuScene laden
    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");

    }
}
