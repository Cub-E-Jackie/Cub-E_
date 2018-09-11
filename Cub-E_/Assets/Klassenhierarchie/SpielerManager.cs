using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  In dieser Klasse wird die Steuerung des Spiels definiert und verwaltet.
  - die Steuerung WÄHREND des Levels
  - die Steuerung des Spielers in horizontaler Richtung, nach links und rechts
  - abhängig von Spielmodus
  - Kollision abfangen und entsprechend andere Funktionen aufrufen
  
*/

public class SpielerManager : MonoBehaviour {
	
	//Vektor zur Speicherung des Nullvektors
	private Vector3 targetPos = Vector3.zero;
	public float step;
    public float smoothing;
    private float animation;

	// Use this for initialization
	void Start () {
		
	}
	
	void Abtauchen (){
		
	}
	
	// Update is called once per frame
	void Update () {
		
	// Spieler bei Tastenbedienung A Bewegung nach links
	if( Input.GetKeyDown( KeyCode.A )){
		targetPos = -(transform.right * step);
	}
	
	//Spieler bei Tastenbedienung D Bewegung nach rechts
	if( Input.GetKeyDown( KeyCode.D )){
		targetPos = transform.right * step;
	}
	
	//Spieler bei Tastenbedienung W Bewegung in einer Parabel über das Hindernis
	if  (Input.GetKeyDown( KeyCode.W )){
		
		animation += Time.deltaTime;
		
		animation = animation % 3f;
		
		Vector3 startposition = transform.position;
		
		transform.position = MathParabola.Parabola(transform.position, new Vector3 (transform.position.x, 4.9f, -4f), 20f, animation/3f);
		
	}
	
	//Bewegungen nach links und rechts abdämpfen mit smoothing
	transform.position += targetPos * smoothing;
    targetPos -= targetPos * smoothing;
	}
}
