using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour {

    public float movementSpeed = 0.004f;
    public float rotationSpeed = 0.8f;
    // Sicherheitsvektor, da der Würfel sich konstant nach oben verschiebt
    public float distanceTolerance = 0.1f; 

    private Vector3 lastNormal = Vector3.zero;
    
	public float rotTimer = 0f;
	//private float rotTimer = 0f;

    void Start () {
    	
    		
	}

	void Update () {
    	
    	
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

            // Wuerfel ist getagged mit "WaterCube"
            if (hit.collider.tag != "WaterCube")
            {
                transform.Rotate(1f, 1f, 0);
;           }
            
        }
        else
        {
            transform.Rotate(1f, 0, 0);
        }
		
     
        transform.Translate(0, 0, movementSpeed);
        
        
       
    	
	}
}






