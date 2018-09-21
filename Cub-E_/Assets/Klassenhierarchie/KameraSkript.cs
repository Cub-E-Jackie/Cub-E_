using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSkript : MonoBehaviour {

	public GameObject kamera;
	
	public GameObject spieler;
	
	public GameObject planeObenVorne;
	
	float zeitGesamt;
	
	public Vector3 startPosition;
       
    float zeitAnteilAlt;

	
	void Start () {
	
	// Aufruf der Funktion Startbewegung
	
	    zeitGesamt = 3f;
                zeitAnteilAlt = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(SpielerManager.drehX){
			
			float x = SpielerManager.plane.transform.position.x;
			float y = SpielerManager.plane.transform.position.y;
			float z = SpielerManager.plane.transform.position.z;
			
			Vector3 drehPunkt = new Vector3 (x, y, z);
						
			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
			
			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
			
			transform.RotateAround ( drehPunkt, SpielerManager.drehAchse, winkelAenderung );
			
			zeitAnteilAlt = zeitAnteil;
			
			Debug.Log(transform.eulerAngles.x);
			
			if(zeitAnteil >= 1f){
				SpielerManager.drehX = false;
			}
		}
		
		//transform.LookAt(spieler.transform);
	}
}