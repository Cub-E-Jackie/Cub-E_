using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool PausedGame = false;
	public GameObject pauseMenu;
	
	 DuckMovement zeit;
	
	// Update is called once per frame
	void Update () {
		zeit = GameObject.Find("Player").GetComponent<DuckMovement>();
		
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
		zeit.rotTimer = 0f;
		zeit.movementSpeed = 1f;
		zeit.rotationSpeed = 0.01f;
		zeit.distanceTolerance = 0.1f;
				
		//Time.timeScale = 1f; //Zeit wieder weiter laufen lassen
		PausedGame = false;
	}
	
	public void Pause() {
		pauseMenu.SetActive(true);
		zeit.rotTimer = 0f;
		zeit.movementSpeed = 0f;
		zeit.rotationSpeed = 0f;
		zeit.distanceTolerance = 0f;
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

