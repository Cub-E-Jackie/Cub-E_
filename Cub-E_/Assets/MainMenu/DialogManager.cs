using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour {

	public TextMeshProUGUI textShow;
	public string[] sentences; //die Saetze für Dialog
	private int i;
	public float speed; //Geschwindigkeit in der geschrieben wird
	public GameObject button; //Continue Button für weiter
	
	
	
	void Start(){
		StartCoroutine(Type()); //Weitergabe an Unity
	}
	
	void Update () {
		if(textShow.text == sentences[i]) { //damit die Sätze nacheinander abgebildet und nicht gleichzeitig	
		button.SetActive(true); // Button angezeigt nachdem Satz fertig
		}
	}
	
	//Text anzeigen
	IEnumerator Type(){
		foreach(char letter in sentences[i].ToCharArray()){
			textShow.text += letter;
			yield return new WaitForSeconds(speed);
		}
	}
	
	//damit nach Continue Button drücken neuer Satz gezeigt wird
	public void NextSentence(){
		button.SetActive(false);
		if(i<sentences.Length - 1){
			i++; //+1 gerechnet
			textShow.text = "";
			StartCoroutine(Type());
		} else {
			//nächste Scene starten = Scene, nachdem alle Sätze angezeigt wurden 
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
			button.SetActive(false); //Button active = false		
		}
	}	
}
