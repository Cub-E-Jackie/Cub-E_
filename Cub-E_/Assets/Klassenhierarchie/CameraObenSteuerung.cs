using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	In dieser Klasse wird das Verhalten und die Positionen der KameraOben in dem Spiel verwaltet. 
	- Kamera wird gedreht, wenn Player mit Plane ObenVorne kollidiert
	- wenn Animation fertig ist, wird auf Kamera vorne gewechselt
	- Kamera Oben wird wieder an Ausgangsposition gesetzt und Ausgangsrotation eingestellt
	- Kollision wird wieder auf false gesetzt
*/

public class CameraObenSteuerung : MonoBehaviour {

	// alle Kameras
	public Camera kameraOben;
	public Camera kameraUnten;
	public Camera kameraHinten;
	public Camera kameraVorne;
	
	// für die Animation RotateAround()
	float zeitGesamt;   
    float zeitAnteilAlt;
    float rotationsSpeed = 5f;

	
    // Aufruf der Funktion Startbewegung
	void Start () {
	
	    zeitGesamt = 1.5f;
        zeitAnteilAlt = 0;
		
	}
	
	
	void Update () {
		
		if(SpielerInput.drehOV){
			
			kameraOben.enabled = true;
			kameraUnten.enabled = false;
			kameraHinten.enabled = false;
			kameraVorne.enabled = false;
		
			float zeitAnteil = (Time.time - SpielerInput.bewegungZeitStart) / zeitGesamt;
			
			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * 90f;
			
			kameraOben.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
			
			zeitAnteilAlt = zeitAnteil;
						
			if(zeitAnteil >= 1f)
			{
			
				kameraOben.enabled = false;
				kameraUnten.enabled = false;
				kameraHinten.enabled = false;
				kameraVorne.enabled = true;
			
				float kameraPositionX = 0;
				float kameraPositionY = 11.48f;
				float kameraPositionZ = -6.97f;
				
				kameraOben.transform.position = new Vector3(kameraPositionX, kameraPositionY, kameraPositionZ);
				
				kameraOben.transform.rotation = Quaternion.Slerp(transform.rotation, SpielerInput.originalDrehOben, Time.time * rotationsSpeed);
									
				//Variablen zurücksetzen
				zeitGesamt = 1.5f;
    			zeitAnteilAlt = 0;
				SpielerInput.drehOV = false;
			
			}
		}
	}
}
