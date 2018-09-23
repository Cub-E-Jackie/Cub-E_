
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool PausedGame = false;
	public GameObject pauseMenu;
	
	DuckMovement zeit; //Zugreifen auf DuckMovement
	
	// Update is called once per frame
	void Update () {
		zeit = GameObject.Find("Player").GetComponent<DuckMovement>(); //Zugreifen auf DuckMovement, zeit definieren
		
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (PausedGame){
				Resume(); //Game wieder starten	
			} else {
				Pause(); //Game Pause
			}
		}
	}
	
	//Pause aufheben 
	public void Resume() {
		pauseMenu.SetActive(false); 
		zeit.activModus = true; 
		Time.timeScale = 1f; //Zeit wieder weiter laufen lassen
		PausedGame = false;
	}
	
	//Pause einstellen
	public void Pause() {
		
		pauseMenu.SetActive(true); 
		zeit.activModus = false; //auf activeModus von DuckMovement zugreifen und Bewegung ausschalten
		Time.timeScale = 0f; // in Bewegungen einfrieren*/
		PausedGame = true; //Game pausiert
	}
	
	
	//Bei auf Menu drücken: auf Menu wechseln
	public void LoadMenu() {
		Debug.Log("Load menu..."); //wird ausgeschrieben
		Time.timeScale = 1f;
		//Pause Menu wieder false um es auszustellen
		pauseMenu.SetActive(false); 
		PausedGame = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1); //-1 um zurück zu MainMenu
		
	}
	
}

