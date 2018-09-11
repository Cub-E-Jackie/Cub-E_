using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenü : MonoBehaviour {


	public void PlayGame () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //nächste Scene starten = Game
	}

	public void QuitGame() {
	Debug.Log("Quit");//Schreibt: Quit in Console
		Application.Quit(); 
	}
}
