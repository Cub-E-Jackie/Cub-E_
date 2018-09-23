using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVorneSteuerung : MonoBehaviour {

	public Camera kameraOben;
	public Camera kameraUnten;
	public Camera kameraLinks;
	public Camera kameraRechts;
	public Camera kameraHinten;
	public Camera kameraVorne;
	
	
	
	float rotationsSpeed = 5f;
	
	
	float zeitGesamt;
    
    //float SpielerInput.winkelGesamt;
    
    float zeitAnteilAlt;

	
	void Start () {
	
	// Aufruf der Funktion Startbewegung
	
	    zeitGesamt = 1.5f;
        //SpielerInput.winkelGesamt = 90f;
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
					float kameraPositionY = 6.3f;
					float kameraPositionZ = 10.1f;
					
					kameraVorne.transform.position = new Vector3(kameraPositionX, kameraPositionY, kameraPositionZ);
					
					kameraVorne.transform.rotation = Quaternion.Slerp(transform.rotation, SpielerInput.originalDrehVorne, Time.time * rotationsSpeed);
					
					SpielerInput.drehUV = false;
					zeitGesamt = 1.5f;
        //SpielerInput.winkelGesamt = 90f;
        zeitAnteilAlt = 0;
		
					
				}
		
		}
		
		
		
		
		
		
	
	
	
		
	
		
	
		
		
	
	
		//transform.LookAt(spieler.transform);
		
	}
}