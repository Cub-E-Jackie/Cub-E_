using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// noch nicht funktionsfähig, muss noch angepassz werden

/*
  In dieser Klasse wird die Steuerung des Spiels definiert und verwaltet.
  - die Steuerung WÄHREND des Levels
  - die Steuerung des Spielers in horizontaler Richtung, nach links und rechts
  - abhängig von Spielmodus
  - Kollision abfangen und entsprechend andere Funktionen aufrufen
  - LERP der Ente
  
*/

public class SpielerInput	: MonoBehaviour {


	public Rigidbody drehKin;

    //Vektor zur Speicherung des Nullvektors
    private Vector3 targetPos = Vector3.zero;
	public float step;
    public float smoothing;


    public GameObject duckPref;
    public GameObject worldCube;
    
    public GameObject test;
    public float turnSpeed = 50f;
   
    
    public static  float winkelGesamt;
        
    public GameObject planeObenVorne;
    
    public static bool drehOV;
    public static bool drehOH;
    public static bool drehOL;
    public static bool drehOR;
    public static bool drehUV;
    public static bool drehUH;
    public static bool drehUR;
    public static bool drehUL;
    public static bool drehVR;
    public static bool drehVL;
    public static bool drehHR;
    public static bool drehHL;
    
    public Camera kameraOben;
	public Camera kameraUnten;
	public Camera kameraLinks;
	public Camera kameraRechts;
	public Camera kameraHinten;
	public Camera kameraVorne;
	
	public static Quaternion originalDrehOben;
	public static Quaternion originalDrehVorne;
	public static Quaternion originalDrehUnten;
	public static Quaternion originalDrehHinten;
	public static Quaternion originalDrehLinks;
	public static Quaternion originalDrehRechts;
    
    
    public GameObject duck;
    
    
    public bool sprungSchalter;
 
    public bool jumping = false;
    
    public float jump = 0;
    
    public float zeitSchaltuhrStart;
    
    public float sprungSperre;
    
    public float sprungZeitAlt;
    
    public bool sperreLinks;
    public bool sperreRechts;
    
   
    
//    float zeitGesamt;
//    
//    float winkelGesamt;
//    
   public static float bewegungZeitStart;
//    
//    float zeitAnteilAlt;
    
  

	// Use this for initialization
	void Start () {
		
		sperreLinks = true;
		sperreRechts = true;
		
		sprungSperre = 0.3f;
		sprungZeitAlt = 0;
		sprungSchalter = true;

        duck = Instantiate(duckPref);

        duck.name = "Duck";
        duck.transform.parent = this.transform;
        duck.transform.position = transform.position;
        
        originalDrehOben = kameraOben.transform.rotation;
        originalDrehVorne = kameraVorne.transform.rotation;
		originalDrehHinten = kameraHinten.transform.rotation;
        originalDrehUnten = kameraUnten.transform.rotation;
		originalDrehLinks = kameraLinks.transform.rotation;
        originalDrehRechts = kameraRechts.transform.rotation; 
        
        drehOV = false;
        drehOH = false;
    	drehOL = false;
    	drehOR = false;
    	drehUV = false;
    	drehUH = false;
    	drehUR = false;
    	drehUL = false;
    	drehVR = false;
    	drehVL = false;
    	drehHR = false;
    	drehHL = false;
    	
		kameraOben.enabled = true;
		kameraUnten.enabled = false;
 		kameraLinks.enabled = false;
		kameraRechts.enabled = false;
		kameraHinten.enabled = false;
		kameraVorne.enabled = false;
		
		drehKin = GetComponent<Rigidbody>();
    	
//        zeitGesamt = 3f;
//        winkelGesamt = 90f;
//        zeitAnteilAlt = 0;
	}
	
//	void Springen(){
//		
//			
//		jump += 1.5f;
//		
//		transform.position += transform.up * Mathf.Sin(jump);
//		
//		if( jump <= Mathf.PI){
//				
//			jumping = false;
//			jump = 0;
//			
//		}
//	}
	
	void OnTriggerExit(Collider coll){
		
		if ( coll.gameObject.tag == "PlaneObenVorne")
		{
			drehOV = true;
			
			bewegungZeitStart = Time.time;
			
		}
		
		if ( coll.gameObject.tag == "PlaneObenHinten")
		{
			drehOH = true;
			
			bewegungZeitStart = Time.time;
			
		}
		
		if ( coll.gameObject.tag == "PlaneObenRechts")
		{
			drehOR = true;
			
			sperreRechts = true;
			
			//CameraRechtsSteuerung.drehRechts = true;	
		}
		
		if ( coll.gameObject.tag == "PlaneObenLinks")
		{
			drehOL = true;
			
			sperreLinks = true;
		}
		
		if ( coll.gameObject.tag == "PlaneVorneLinks")
		{
			drehVL = true;
			
			sperreLinks = true;
		}
		
		if ( coll.gameObject.tag == "PlaneVorneRechts")
		{
			drehVR = true;
			
			sperreRechts = true;
			
			//CameraRechtsSteuerung.drehVR = true;
		}
		
		if ( coll.gameObject.tag == "PlaneHintenLinks")
		{
			drehHL = true;
			
			sperreLinks = true;
		}
		
		if ( coll.gameObject.tag == "PlaneHintenRechts")
		{
			drehHR = true;
			
			sperreRechts = true;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenVorne")
		{
			drehUV = true;
			
			bewegungZeitStart = Time.time;
			
		}
		
		if ( coll.gameObject.tag == "PlaneUntenHinten")
		{
			drehUH = true;
			
			bewegungZeitStart = Time.time;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenRechts")
		{
			drehUR = true;
			
			sperreRechts = true;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenLinks")
		{
			drehUL = true;
			
			sperreLinks = true;
		}
		
	}
	
	void OnTriggerStay(Collider coll){
		
		if ( coll.gameObject.tag == "PlaneObenVorne")
		{
			drehOV = true;
			
			bewegungZeitStart = Time.time;
			
		}
		
		if ( coll.gameObject.tag == "PlaneObenHinten")
		{
			drehOH = true;
			
			bewegungZeitStart = Time.time;
			
		}
		
		if ( coll.gameObject.tag == "PlaneObenRechts")
		{
			drehOR = true;
			
			sperreRechts = false;
			
			//CameraRechtsSteuerung.drehRechts = true;	
		}
		
		if ( coll.gameObject.tag == "PlaneObenLinks")
		{
			drehOL = true;
			
			sperreLinks = false;
		}
		
		if ( coll.gameObject.tag == "PlaneVorneLinks")
		{
			drehVL = true;
			
			sperreLinks = false;
		}
		
		if ( coll.gameObject.tag == "PlaneVorneRechts")
		{
			drehVR = true;
			
			sperreRechts = false;
			
			//CameraRechtsSteuerung.drehVR = true;
		}
		
		if ( coll.gameObject.tag == "PlaneHintenLinks")
		{
			drehHL = true;
			
			sperreLinks = false;
		}
		
		if ( coll.gameObject.tag == "PlaneHintenRechts")
		{
			drehHR = true;
			
			sperreRechts = false;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenVorne")
		{
			drehUV = true;
			
			bewegungZeitStart = Time.time;
			
		}
		
		if ( coll.gameObject.tag == "PlaneUntenHinten")
		{
			drehUH = true;
			
			bewegungZeitStart = Time.time;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenRechts")
		{
			drehUR = true;
			
			sperreRechts = false;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenLinks")
		{
			drehUL = true;
			
			sperreLinks = false;
		}
		
	}
	
//	void OnCollisionEnter(Collision coll){
//		
//		if ( coll.gameObject.tag == "PlaneVorneOben")
//		{
//			drehX = true;
//			
//			
//
//		}
//		
//	}

	
	// Update is called once per frame
	void Update () { 

//		if (CameraRechtsSteuerung.drehRechts){
//			
//			targetPos = -(transform.right * (5f*step));
//			
//		}
//		
	// Spieler bei Tastenbedienung A Bewegung nach links
	if( Input.GetKeyDown( KeyCode.A ) && sperreLinks){
		
		targetPos = -(transform.right * step);
		
	}
	
	
//	if (CameraRechtsSteuerung.drehRechts){
//		
//		drehKin.isKinematic = false;
//		
//		GetComponent<Rigidbody>().AddTorque(0, 45f , -90f);
//		drehKin.isKinematic = true;
//		
//	}
	
	if (CameraRechtsSteuerung.drehVR){
		
		//GetComponent<Rigidbody>().AddTorque(0, -90f, 45f);
		
	}
	
	
	
	//Spieler bei Tastenbedienung D Bewegung nach rechts
	if( Input.GetKeyDown( KeyCode.D ) && sperreRechts ){
		
		targetPos = transform.right * step;
		
	}	
	
	if (sprungSchalter){
	
	//Spieler bei Tastenbedienung Leertaste Bewegung in einer Parabel über das Hindernis
	if  (Input.GetKeyDown( KeyCode.Space ) && !jumping){
				
		jumping = true;
		
		zeitSchaltuhrStart = Time.time;
		
	}
	
	}
	
	else {
		
		float zeitSperre = 1.5f;
		float vergangen = Time.time - zeitSchaltuhrStart;
			
			if(vergangen > zeitSperre){
			
			sprungSchalter = true;
		}
	}

	
	if (jumping){
		
		sprungSchalter = false;
		
		float zeitAnteil = (Time.time - zeitSchaltuhrStart)/sprungSperre;
				
		jump = (zeitAnteil - sprungZeitAlt) * 1.5f;
		
		//zeitAnteil = zeitAnteil - sprungZeitAlt;
		
		transform.position += transform.up * Mathf.Sin(jump);
		
		sprungZeitAlt = zeitAnteil;
		
		if( zeitAnteil >= 1f){
				
			jumping = false;
			jump = 0;
			
			sprungSperre = 0.3f;
			sprungZeitAlt = 0;
			sprungSchalter = false;
			
		}
		
	}
		
//	else if( Input.GetKeyDown( KeyCode.H ) && !drehX){
//		
//		Debug.Log("Ente in Platte");
//		
//		drehX = true;
//
//		bewegungZeitStart = Time.time;
//		
//	}
	
	
	
//	if(drehX){
////		
//		bewegungZeitStart = Time.time;
//		
//		zeitAnteil = (Time.time - bewegungZeitStart) / zeitGesamt;
////		
//		winkelAenderung = (zeitAnteil - zeitAnteilAlt) * winkelGesamt;
////		
////		kamera.transform.RotateAround( new Vector3(0, 10f, -10f), new Vector3(1f, 0, 0), winkelAenderung );
////		
//		zeitAnteilAlt = zeitAnteil;
////		
////		Debug.Log(kamera.transform.eulerAngles.x);
////		
//		if(zeitAnteil >= 1f){
//			drehX = false;
//		}
////		
//	}
////	
	
	//Bewegungen nach links und rechts abdämpfen mit smoothing
	transform.position += targetPos * smoothing;
    targetPos -= targetPos * smoothing;

    }
}

