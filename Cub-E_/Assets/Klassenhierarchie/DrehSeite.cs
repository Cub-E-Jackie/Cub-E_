using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrehSeite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	if (CameraRechtsSteuerung.drehRechts){
		
		GetComponent<Rigidbody>().AddTorque(95f,  95f, -95f);
		
	}
	
	if (Input.GetKeyDown( KeyCode.Z )){
		
		GetComponent<Rigidbody>().AddTorque(0, 0, -95f);
		
	}
		
	}
}
