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

    // fuer Sound
    private AudioSource source;
	
	
	void Start(){

        //Zuweisung der Audio Source
        source = GetComponent<AudioSource>();
		StartCoroutine(Type()); //Weitergabe an Unity
	}
	
	void Update () {
		//damit die Sätze nacheinander abgebildet und nicht gleichzeitig	
		if(textShow.text == sentences[i]) { 
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

        // Spielt den Click Sound bei Continue
        source.Play();

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
