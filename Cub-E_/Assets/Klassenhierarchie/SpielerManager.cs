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
    
    public float zeitGesamt;
    
    public GameObject kamera;
            
    public static bool drehX;
    
    public static float bewegungZeitStart;
     
    public static float winkelGesamt;
    
    public float startKameraX;
    
    public float startKameraY;
    
    public float startKameraZ;
    
    public static Vector3 drehPunkt;
    
    public static Vector3 drehAchse;

	// Use this for initialization
	void Start () {

        duck = Instantiate(duckPref);

        duck.name = "Duck";
        duck.transform.parent = this.transform;
        duck.transform.position = transform.position;
        
        drehX = false;
        
//      startKameraX = 0;
//		startKameraY = 15f;
//		startKameraZ = 0;
       
	}
	
	void OnTriggerExit(Collider coll){
		
		if ( coll.gameObject.tag == "PlaneObenHinten")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = -90f;
			
			
			
			drehAchse = new Vector3(5f, 0, 0);
		}
		
		if ( coll.gameObject.tag == "PlaneObenVorne")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 180f;	
			
			plane = planeObenVorne;
			
			drehAchse = new Vector3(5f, 0, 0);			
			
		}
		
		if ( coll.gameObject.tag == "PlaneObenLinks")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90f;
		}
		
		if ( coll.gameObject.tag == "PlaneObenRechts")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90f;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenVorne")
		{
//			startKameraX = kamera.transform.position.x;
//			startKameraY = kamera.transform.position.y;
//			startKameraZ = kamera.transform.position.z;
			
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = -90f;
			
			plane = planeUntenVorne;
						
			drehAchse = new Vector3(1f, 0, 0);
		}
		
		if ( coll.gameObject.tag == "PlaneUntenHinten")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90f;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenLinks")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90f;
		}
		
		if ( coll.gameObject.tag == "PlaneUntenRechts")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90f;
		}
		
		if ( coll.gameObject.tag == "PlaneVorneLinks")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90f;
		}
		
		if ( coll.gameObject.tag == "PlaneVorneRechts")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90f;
		}
		
		if ( coll.gameObject.tag == "PlaneHintenLinks")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90f;
		}
		
		if ( coll.gameObject.tag == "PlaneHintenRechts")
		{
			drehX = true;
			
			bewegungZeitStart = Time.time;
			
			winkelGesamt = 90f;
		}
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
		
		GetComponent<Rigidbody>().AddTorque(0,5f,0);
		
	}
	
	if (Input.GetMouseButtonDown(1)){
		
		GetComponent<Rigidbody>().AddTorque(0,-5f,0);
		
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

