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

public class CameraVorneSteuerung : MonoBehaviour {

	// alle Kameras
	public Camera kameraOben;
	public Camera kameraUnten;
	public Camera kameraLinks;
	public Camera kameraRechts;
	public Camera kameraHinten;
	public Camera kameraVorne;
	
	
	// für die Animation RotateAround()
	float zeitGesamt;
  	float rotationsSpeed = 5f;
    float zeitAnteilAlt;

	// Aufruf der Funktion Startbewegung
	void Start () {
	
	    zeitGesamt = 1.5f;
        zeitAnteilAlt = 0;
       
	}
	

	
	// Update is called once per frame
	void Update () {	
	
		if(SpielerInput.drehUV){
			
			kameraOben.enabled = false;
			kameraUnten.enabled = false;
	 		kameraLinks.enabled = false;
			kameraRechts.enabled = false;
			kameraHinten.enabled = false;
			kameraVorne.enabled = true;
		
			float zeitAnteil = (Time.time - SpielerInput.bewegungZeitStart) / zeitGesamt;
			
			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * 90f;
			
			kameraVorne.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
			
			zeitAnteilAlt = zeitAnteil;
			
			Debug.Log(transform.eulerAngles.x);
			
			if(zeitAnteil >= 1f)
				{
					
					kameraOben.enabled = false;
					kameraUnten.enabled = true;
			 		kameraLinks.enabled = false;
					kameraRechts.enabled = false;
					kameraHinten.enabled = false;
					kameraVorne.enabled = false;
					
				
					float kameraPositionX = 0;
					float kameraPositionY = 6.63f;
					float kameraPositionZ = 11.64f;
					
					kameraVorne.transform.position = new Vector3(kameraPositionX, kameraPositionY, kameraPositionZ);
					
					kameraVorne.transform.rotation = Quaternion.Slerp(transform.rotation, SpielerInput.originalDrehVorne, Time.time * rotationsSpeed);
					
					SpielerInput.drehUV = false;
					zeitGesamt = 1.5f;
        			zeitAnteilAlt = 0;
		
					
				}
		
		}
		
		
		
		
		
		
	
	
	
		
	
		
	
		
		
	
	
		//transform.LookAt(spieler.transform);
		
	}
}