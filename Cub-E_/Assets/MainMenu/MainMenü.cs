using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenü : MonoBehaviour {

PauseMenu start;
	
	public void PlayGame () {
		//start = GameObject.Find("Menu").GetComponent<PauseMenu>();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //nächste Scene starten = Game
		//start.pauseMenu.SetActive(false);
		//start.PausedGame = false;

	}

	public void QuitGame() {
	Debug.Log("Quit");//Schreibt: Quit in Console
		Application.Quit(); 
	}
}
