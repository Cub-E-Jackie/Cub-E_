using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool PausedGame = false;
	public GameObject pauseMenu;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (PausedGame){
				Resume(); //Game wieder starten
			} else {
				Pause(); //Game Pause
			}
		}
	}
	
	public void Resume() {
		pauseMenu.SetActive(false);
		//Time.timeScale = 1f; //Zeit wieder weiter laufen lassen
		PausedGame = false;
	}
	
	public void Pause() {
		pauseMenu.SetActive(true);
		//Time.timeScale = 0f; // in Bewegungen einfrieren)
		PausedGame = true; //Game pausiert
	}
	
	/*public void Restart() {
		pauseMenu.SetActive(false);
		PausedGame = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0); 
		
	}*/

	//ACHTUNG!! BEI MENu zu Spiel ist PAUSE MENÜ NOCH DA???
	public void LoadMenu() {
		Debug.Log("Load menu...");
		//Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
		pauseMenu.SetActive(false);
		PausedGame = false;
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0); 
		
	}
	
}

