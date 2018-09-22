using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSkript : MonoBehaviour {

	public Camera kameraOben;
	public Camera kameraUnten;
	public Camera kameraLinks;
	public Camera kameraRechts;
	public Camera kameraHinten;
	public Camera kameraVorne;
	
	
	float zeitGesamt;
	
    float zeitAnteilAlt;

	
	void Start () {
	
	// Aufruf der Funktion Startbewegung
	
	    zeitGesamt = 3f;
        zeitAnteilAlt = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(SpielerManager.drehOV){
			
			kameraOben.enabled = true;
			kameraUnten.enabled = false;
	 		kameraLinks.enabled = false;
			kameraRechts.enabled = false;
			kameraHinten.enabled = false;
			kameraVorne.enabled = false;
		
			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
			
			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
			
			kameraOben.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
			
			zeitAnteilAlt = zeitAnteil;
			
			Debug.Log(transform.eulerAngles.x);
			
			if(zeitAnteil >= 1f)
				{
					SpielerManager.drehOV = false;
				}
		
		}
		
//		if(SpielerManager.drehOH){
//			
//			kameraOben.enabled = true;
//			kameraUnten.enabled = false;
//	 		kameraLinks.enabled = false;
//			kameraRechts.enabled = false;
//			kameraHinten.enabled = false;
//			kameraVorne.enabled = false;
//		
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			kameraOben.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehOH = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehOR){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			kameraRechts.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehOR = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehOL){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			kameraLinks.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehOL = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehUV){
//			
//			kameraOben.enabled = false;
//			kameraUnten.enabled = false;
//	 		kameraLinks.enabled = false;
//			kameraRechts.enabled = false;
//			kameraHinten.enabled = true;
//			kameraVorne.enabled = false;
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			kameraHinten.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehUV = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehVR){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			kameraRechts.transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehVR = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehVL){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehVL = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehUR){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehUR = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehUL){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehUL = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehUH){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehUH = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehHL){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehHR = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehHL){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehHL = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehOV){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehOV = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehOV){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehOV = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehOV){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehOV = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehOV){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehOV = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehOV){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehOV = false;
//				}
//		
//		}
//		
//		if(SpielerManager.drehOV){
//		
//			float zeitAnteil = (Time.time - SpielerManager.bewegungZeitStart) / zeitGesamt;
//			
//			float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * SpielerManager.winkelGesamt;
//			
//			transform.RotateAround ( new Vector3(1f, 0, 0), new Vector3(5f, 0, 0), winkelAenderung );
//			
//			zeitAnteilAlt = zeitAnteil;
//			
//			Debug.Log(transform.eulerAngles.x);
//			
//			if(zeitAnteil >= 1f)
//				{
//					SpielerManager.drehOV = false;
//				}
//		
//		}
//		
		//transform.LookAt(spieler.transform);
	}
}