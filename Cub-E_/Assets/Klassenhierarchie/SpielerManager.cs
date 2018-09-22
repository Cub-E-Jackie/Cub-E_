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

public class SpielerManager : MonoBehaviour {

//    // fuer konstante Bewegung der Ente
//    public float movementSpeed = 1f;
//    public float rotationSpeed = 0.01f;
//    // Sicherheitsvektor, da der Würfel sich konstant nach oben verschiebt
//    public float distanceTolerance = 0.1f;
//    
   

    private Vector3 lastNormal = Vector3.zero;
    private float Timer = 0f;
    
    float jump = 0;


    //Vektor zur Speicherung des Nullvektors
    private Vector3 targetPos = Vector3.zero;
	public float step;
    public float smoothing;
    //private float animation;
    //private bool springe = false;
    Vector3 sprungStartPosition = Vector3.zero;

    public GameObject duckPref;
    public GameObject worldCube;
    
    public float turnSpeed = 50f;
    
    public static GameObject plane;
    
    public GameObject planeObenVorne;
    
    public GameObject planeUntenVorne;
       
    public GameObject duck;
    
    public bool jumping = false;
    
    
    
    public GameObject kamera;
            
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
    
    
    public static float bewegungZeitStart;
     
    public static float winkelGesamt;
        
   

	// Use this for initialization
	void Start () {

        duck = Instantiate(duckPref);

        // sound
        FindObjectOfType<AudioManager>().Play("PlayerDuck");

        duck.name = "Duck";
        duck.transform.parent = this.transform;
        duck.transform.position = transform.position;
        
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
        
		
       
	}
	
	void OnTriggerExit(Collider coll){
		
		if ( coll.gameObject.tag == "PlaneObenVorne")
		{
			Debug.Log("In Kollision mit OV");
			
			drehOV = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90;
		}
		
//		if ( coll.gameObject.tag == "PlaneObenHinten")
//		{
//			drehOH = true;
//			
//			bewegungZeitStart = Time.time;
//			
//			winkelGesamt = -90;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneObenRechts")
//		{
//			drehOR = true;
//			
//			bewegungZeitStart = Time.time;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneObenLinks")
//		{
//			drehOL = true;
//			
//			bewegungZeitStart = Time.time;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneVorneLinks")
//		{
//			drehVL = true;
//			
//			bewegungZeitStart = Time.time;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneVorneRechts")
//		{
//			drehVR = true;
//			
//			bewegungZeitStart = Time.time;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneHintenLinks")
//		{
//			drehHL = true;
//			
//			bewegungZeitStart = Time.time;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneHintenRechts")
//		{
//			drehHR = true;
//			
//			bewegungZeitStart = Time.time;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneUntenVorne")
//		{
//			drehUV = true;
//			
//			bewegungZeitStart = Time.time;
//			
//			winkelGesamt = 90;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneUntenHinten")
//		{
//			drehUH = true;
//			
//			bewegungZeitStart = Time.time;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneUntenRechts")
//		{
//			drehUR = true;
//			
//			bewegungZeitStart = Time.time;
//		}
//		
//		if ( coll.gameObject.tag == "PlaneUntenLinks")
//		{
//			drehUL = true;
//			
//			bewegungZeitStart = Time.time;
//		}
	}
	
	void Springen(){
		
			
		jump += 1.5f;
		
		transform.position += transform.up * Mathf.Sin(jump);
		
		if( jump <= Mathf.PI){
				
			jumping = false;
			jump = 0;
			
		}
	}
	


	/*
    void DuckMovement() //eigene Klasse
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit)) // in hit wird Treffer gespeichert
        {
            lastNormal = hit.normal;

            // timer für die lineare Interpolation (LERP) siehe unten: wenn neue normale gefunden dann starte den interp. Timer
            // mit rotation, da er sonst zu schnell die oberflaeche verlaesst
            if (transform.up != hit.normal)
            {
                rotTimer += Time.deltaTime * rotationSpeed;
            }
            else
            {
                rotTimer = 0;
            }
            transform.up = Vector3.Lerp(transform.up, hit.normal, rotTimer); // weiche interpolation der rotation

            // prüfe ob sich GO zu weit von der oberfläche entfernt - und steuer dagegen
            if (Vector3.Distance(transform.position, hit.point) > distanceTolerance)
            {
                transform.Translate(0, -0.05f, 0);
            }

            // Wuerfel ist getagged mit "WorldCube"
            if (hit.collider.tag != "World_Cube_01")
            {
                transform.Rotate(1f, 0, 0);
                
            }

        }
        else
        {
            transform.Rotate(1f, 0, 0);
        }

        transform.Translate(0, 0, movementSpeed);
    }
	*/
	
	// Update is called once per frame
	void Update () { 

		
	// Spieler bei Tastenbedienung A Bewegung nach links
	if( Input.GetKeyDown( KeyCode.A )){
		
		targetPos = -(transform.right * step);
		
	}
	
	if (Input.GetMouseButtonDown(0)){
		
		GetComponent<Rigidbody>().AddTorque(0,95f,0);
		
	}
	
	if (Input.GetMouseButtonDown(1)){
		
		GetComponent<Rigidbody>().AddTorque(0,-95f,0);
		
	}
	
	
	
	//Spieler bei Tastenbedienung D Bewegung nach rechts
	if( Input.GetKeyDown( KeyCode.D )){
		
		targetPos = transform.right * step;
		
	}
	
	//Spieler bei Tastenbedienung Leertaste Bewegung in einer Parabel über das Hindernis
	if  (Input.GetKeyDown( KeyCode.Space ) && !jumping){
				
		jumping = true;
		
	}
	
	if (jumping){
		
		Springen();
		
	}
	


	
	//Bewegungen nach links und rechts abdämpfen mit smoothing
	transform.position += targetPos * smoothing;
    targetPos -= targetPos * smoothing;

    }
}

