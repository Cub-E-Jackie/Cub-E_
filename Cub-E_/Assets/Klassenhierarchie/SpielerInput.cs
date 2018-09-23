using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  In dieser Klasse wird die Steuerung des Spiels definiert und verwaltet.
  - die Steuerung des Players: A - Bewegung nach links
  							   D - Bewegung nach rechts
  						   Space - Sprungbewegung (begrenzt!)
  - OnTriggerEnter() für die Planes auf den Kanten und den damit erzeugten Kameraanimationen
  - OnTriggerStay() für die Planes jeweils links und rechts für die Begrenzung der Steuerung  
*/

public class SpielerInput	: MonoBehaviour {


    //Vektor zur Speicherung des Nullvektors
    private Vector3 targetPos = Vector3.zero;
	// Bewegungen nach links und rechts weicher machen/ abdämpfen
    public float step;
    public float smoothing;


    public GameObject duckPref;
    public GameObject worldCube;
    public GameObject duck;
    public GameObject test;
    public float turnSpeed = 50f;
    
   
    //Variablen zum Aufruf der Kameraanimationen der jeweiligen Kameraklasse 
    //oder der Auslösung der Blockierung der Bewegung
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
    
    //Variable für Zeitorganisation während Kameranimation (Weitergabe an jeweilige Klasse)
    public static float bewegungZeitStart;
    
    //Variablen zur Speicherung der Kameraobjekte (für Speicherung der Rotationsdaten)
    public Camera kameraOben;
	public Camera kameraUnten;
	public Camera kameraHinten;
	public Camera kameraVorne;
	
	//Variablen zur Speicherung der Rotationsdaten 
	//(Typ Quaternion, damit sich die Achsen nicht übereinander verschieben)
	public static Quaternion originalDrehOben;
	public static Quaternion originalDrehVorne;
	public static Quaternion originalDrehUnten;
	public static Quaternion originalDrehHinten;
    
    
    //Variablen zur Realisierung und Begrenzung der Sprungbewegung
    public bool sprungSchalter;
    public bool jumping = false;
    public float jump = 0;
    public float zeitSchaltuhrStart;
    public float sprungSperre;
    public float sprungZeitAlt;
    
    //Variablen für die Blockierung der Link- und Rechtsbewegung
    public bool sperreLinks;
    public bool sperreRechts;
     
	void Start () {
    	
    	duck = Instantiate(duckPref);
        duck.name = "Duck";
        duck.transform.parent = this.transform;
        duck.transform.position = transform.position;
		
		//zu Beginn Links- und Rechtsbewegung möglich
		sperreLinks = true;
		sperreRechts = true;
		
		//Zeit in der Sprung gesperrt ist und Variable zur Blockierung des Sprungs selber
		//zu Beginn Sprung möglich
		sprungSperre = 0.3f;
		sprungZeitAlt = 0;
		sprungSchalter = true;
		
        //Initialisierung der Rotationsdaten in Form von Quaternions der jeweiligen Kameras
        //Ausgangslage
        originalDrehOben = kameraOben.transform.rotation;
        originalDrehVorne = kameraVorne.transform.rotation;
		originalDrehHinten = kameraHinten.transform.rotation;
        originalDrehUnten = kameraUnten.transform.rotation;
	    
		//alle Kollisionsvariablen auf false, zu Beginn keine Kollision        
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
    	
    	//zu Beginn des Spiels startet Spieler oben auf dem Würfel, somit Kamera oben aktiviert, 
    	//andere Kameras deaktiviert
		kameraOben.enabled = true;
		kameraUnten.enabled = false;
 		kameraHinten.enabled = false;
		kameraVorne.enabled = false;
		
	}
	

	// Abfangen des Triggers der jeweiligen Plane, welche durchstoßen wurde, beim Austreten aus der Plane ausgeführt
	// bei Oben, Unten, Vorne, Hinten : aktivieren der jeweiligen Funktion in der betreffenden Klasse der Kamera und 
	//									Übergabe/Speicherung der Startzeit der Animation
	// bei Links, Rechts : Aktivieren der jeweiligen Links- oder Rechtsbewegung, damit der Spieler wieder steuern kann
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
			
		}
		
		if ( coll.gameObject.tag == "PlaneHintenLinks")
		{
			drehHL = true;
			
			sperreRechts = true;
		}
		
		if ( coll.gameObject.tag == "PlaneHintenRechts")
		{
			drehHR = true;
			
			sperreLinks = true;
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
	
	
	
	// Abfangen des Triggers der jeweiligen Plane, welche gerade durchstoßen wird 
	// bei Links, Rechts : Deaktivieren der jeweiligen Links- oder Rechtsbewegung, damit der Spieler nicht steuern kann
	void OnTriggerStay(Collider coll){
		
		
		if ( coll.gameObject.tag == "PlaneObenRechts")
		{
			sperreRechts = false;	
		}
		
		if ( coll.gameObject.tag == "PlaneObenLinks")
		{
			sperreLinks = false;
		}
		
		if ( coll.gameObject.tag == "PlaneVorneLinks")
		{
			sperreLinks = false;
		}
		
		if ( coll.gameObject.tag == "PlaneVorneRechts")
		{
			sperreRechts = false;			
		}
		
		if ( coll.gameObject.tag == "PlaneHintenLinks")
		{
			sperreRechts = false;
		}
		
		if ( coll.gameObject.tag == "PlaneHintenRechts")
		{
			sperreLinks = false;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenRechts")
		{
			sperreRechts = false;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenLinks")
		{
			sperreLinks = false;
		}
		
	}
	
	
	void Update () { 


	// Spieler bei Tastenbedienung A Bewegung nach links, wenn Sperre inaktiv
	if( Input.GetKeyDown( KeyCode.A ) && sperreLinks){
		
		targetPos = -(transform.right * step);
		
	}
	
	//Spieler bei Tastenbedienung D Bewegung nach rechts, wenn Sperre inaktiv
	if( Input.GetKeyDown( KeyCode.D ) && sperreRechts ){
		
		targetPos = transform.right * step;
		
	}	
	
	//nur springen ermöglichen wenn keine Sperre drin
	if (sprungSchalter){
	
		//Spieler bei Tastenbedienung Leertaste Bewegung in einer Parabel über das Hindernis
		if  (Input.GetKeyDown( KeyCode.Space ) && !jumping){
					
			jumping = true;
			
			zeitSchaltuhrStart = Time.time;
			
		}
	}
	
	else {
		
		//Zeit stoppen, Sperre wieder raus und dann kann er wieder springen (Stoppuhr)		
		float zeitSperre = 1.5f;
		float vergangen = Time.time - zeitSchaltuhrStart;
			
			if(vergangen > zeitSperre){
			
			sprungSchalter = true;
		}
	}

	
	//Sprungfunktion selber
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
	
	//Bewegungen nach links und rechts abdämpfen mit smoothing
	transform.position += targetPos * smoothing;
    targetPos -= targetPos * smoothing;

    }
}

