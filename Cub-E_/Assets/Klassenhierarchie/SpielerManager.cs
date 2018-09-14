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
    private float rotTimer = 0f;


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
  
    
    public GameObject duck;
    
    public bool jumping = false;


	// Use this for initialization
	void Start () {

        duck = Instantiate(duckPref);

        duck.name = "Duck";
        duck.transform.parent = this.transform;
        duck.transform.position = transform.position;
	}
	
	void Springen(){
		
		float xWert = 0;
		
		targetPos = transform.up * Mathf.Sin(xWert);
		
		xWert += 0.05f;
		
		if( xWert <= 3.14f){
		jumping = false;
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
	
//	float yEingabe = Input.GetAxis("Vertical");
//	float xEingabe = Input.GetAxis("Horizontal");
//		
//		if ( -10f < yEingabe < 10f){
//		
//			return;
//
//		}
//	
//	float xNeu = transform.position.x + xEingabe * step * Time.deltaTime;
//	
//	if ( xEingabe < -10f ){
//			
//			xNeu = -10f;
//			
//		}
//	
//		if ( 10f < xEingabe ){
//			
//			xNeu = 10f;
//			
//		}
//	
//	float yNeu = transform.position.y + yEingabe * step * Time.deltaTime;
//	
//		if ( -10f > yEingabe ){
//			
//			yNeu = -10f;
//			
//		}
//	
//		if ( 10f < yEingabe ){
//			
//			yNeu = 10f;
//			
//	}
	
	//Bewegungen nach links und rechts abdämpfen mit smoothing
	transform.position += targetPos * smoothing;
    targetPos -= targetPos * smoothing;

    }
}
