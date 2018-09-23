using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour {


    public GameObject gameSettings;

    public void RestartScreen()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


}
