using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenü : MonoBehaviour {

	
	public void PlayGame () {
		//nächste Scene starten = Game, BuildIndex in unity festgelegt
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
	}

	public void QuitGame() {
	Debug.Log("Quit");//Schreibt: Quit in Console
		Application.Quit(); 
	}
}
