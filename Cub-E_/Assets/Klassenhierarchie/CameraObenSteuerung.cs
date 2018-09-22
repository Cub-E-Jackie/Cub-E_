using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	In dieser Klasse wird das Verhalten und die Positionen der Kamera in dem Spiel verwaltet. 
	- Am Anfang soll sie weit entfernt auf das ganze Universum von Cube-E zeigen. 
	- Mit einem Klick auf den Startbutton im Startmenü zoomt die Kamera auf den jeweiligen Cube-E.
	- Während des Levels bewegt sich die Kamera mit einer Verzögerung mit dem Spieler nach links und rechts. Also eine verzögerte Verfolgung des Spielers.
	- Bei Kollision mit Hindernis Camera zoomt kurz ein bisschen raus und dann wieder rein zum neuen Spielfeld. 
	- Am Ende, sowohl bei einem Sieg als auch bei einem GameOver wird wieder heraus gezoomt und das Universum sieht man. 
	
	Hinweise aus der Übung von Herrn Pattmann:
	Camera nicht parenten -> langweilig, smooth follow ist das Stichwort Google nicht die Standart Assets (Betrug!!!), 
	Hereinzoomen bei Start auf den Klick auf den Button dann mit Kamrea reinzoomen mithilfe von Vector 3. SmoothDamp, Angabe von Zeit, Beschleunigung, Vectorziel und so weiter
*/

public class CameraObenSteuerung : MonoBehaviour {

	public Camera kameraOben;
	public Camera kameraUnten;
	public Camera kameraLinks;
	public Camera kameraRechts;
	public Camera kameraHinten;
	public Camera kameraVorne;
	
	
	float zeitGesamt;
    
    //float SpielerInput.winkelGesamt;
    
    float zeitAnteilAlt;
    
    float rotationsSpeed = 5f;

	
	void Start () {
	
	// Aufruf der Funktion Startbewegung
	
	    zeitGesamt = 3f;
        //SpielerInput.winkelGesamt = 90f;
        zeitAnteilAlt = 0;
		
	}
	

	
	// Update is called once per frame
	void Update () {
		
		if(SpielerInput.drehOV){
			
			kameraOben.enabled = true;
			kameraUnten.enabled = false;
	 		kameraLinks.enabled = false;
			kameraRechts.enabled = false;
			kameraHinten.enabled = false;
			kameraVorne.enabled = false;
		
			float zeitAnteil = (Time.time - SpielerInput.bewegungZeitStart) / zeitGesamt;
			
			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * 90f;
			
			kameraOben.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
			
			zeitAnteilAlt = zeitAnteil;
			
			Debug.Log(transform.eulerAngles.x);
			
			if(zeitAnteil >= 1f)
				{
				
					kameraOben.enabled = false;
					kameraUnten.enabled = false;
			 		kameraLinks.enabled = false;
					kameraRechts.enabled = false;
					kameraHinten.enabled = false;
					kameraVorne.enabled = true;
				
					float kameraPositionX = 0;
					float kameraPositionY = 15f;
					float kameraPositionZ = 0;
					
					kameraOben.transform.position = new Vector3(kameraPositionX, kameraPositionY, kameraPositionZ);
					
					kameraOben.transform.rotation = Quaternion.Slerp(transform.rotation, SpielerInput.originalDrehOben, Time.time * rotationsSpeed);
					
//					float kameraPositionX = 0;
//					float kameraPositionY = 0;
//					float kameraPositionZ = -15;
//					
//					kameraHinten.transform.position = new Vector3(kameraPositionX, kameraPositionY, kameraPositionZ);
//					
					SpielerInput.drehOV = false;
					
					zeitGesamt = 3f;
        			//SpielerInput.winkelGesamt = 90f;
        			zeitAnteilAlt = 0;
		
					
					
				}
		
		}
		
		
	}
}
