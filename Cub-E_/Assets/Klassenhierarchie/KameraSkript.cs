using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSkript : MonoBehaviour {

	public GameObject kamera;
	
	float zeitGesamt;
    
       
    float zeitAnteilAlt;

	
	void Start () {
	
	// Aufruf der Funktion Startbewegung
	
	    zeitGesamt = 3f;
                zeitAnteilAlt = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(SpielerManager.drehX){
		
			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
			
			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
			
			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
			
			zeitAnteilAlt = zeitAnteil;
			
			Debug.Log(transform.eulerAngles.x);
			
			if(zeitAnteil >= 1f){
				SpielerManager.drehX = false;
			}
		}
	}
}