using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUntenSteuerung : MonoBehaviour {

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
	
	    zeitGesamt = 1.5f;
        //SpielerInput.winkelGesamt = 90f;
        zeitAnteilAlt = 0;
		
	}
	

	
	// Update is called once per frame
	void Update () {	
	
		if(SpielerInput.drehUH){
			
			kameraOben.enabled = false;
			kameraUnten.enabled = true;
	 		kameraLinks.enabled = false;
			kameraRechts.enabled = false;
			kameraHinten.enabled = false;
			kameraVorne.enabled = false;
		
			float zeitAnteil = (Time.time - SpielerInput.bewegungZeitStart) / zeitGesamt;
			
			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * 90f;
			
			kameraUnten.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
			
			zeitAnteilAlt = zeitAnteil;
			
			Debug.Log(transform.eulerAngles.x);
			
			if(zeitAnteil >= 1f)
				{
					SpielerInput.drehUH = false;
				
					kameraOben.enabled = false;
					kameraUnten.enabled = false;
			 		kameraLinks.enabled = false;
					kameraRechts.enabled = false;
					kameraHinten.enabled = true;
					kameraVorne.enabled = false;
				
					float kameraPositionX = 0;
					float kameraPositionY = -12.3f;
					float kameraPositionZ = 6.9f;
					
					kameraUnten.transform.position = new Vector3(kameraPositionX, kameraPositionY, kameraPositionZ);
					
					kameraUnten.transform.rotation = Quaternion.Slerp(transform.rotation, SpielerInput.originalDrehUnten, Time.time * rotationsSpeed);
					
					zeitGesamt = 1.5f;
        //SpielerInput.winkelGesamt = 90f;
        zeitAnteilAlt = 0;
		
					
//					float kameraPositionX = 0;
//					float kameraPositionY = 0;
//					float kameraPositionZ = -15f;
//					
//					kameraVorne.transform.position = new Vector3(kameraPositionX, kameraPositionY, kameraPositionZ);
//					
//					float kameraRotationX = 0f;
//					float kameraRotationY = 180f;
//					float kameraRotationZ = 180f;
//					
//					
//					kameraVorne.transform.Rotate(new Vector3(kameraRotationX, kameraRotationY, kameraRotationZ), Space.World);
				}
		
		}
		
		
		
	
	
		//transform.LookAt(spieler.transform);
		
	}
}