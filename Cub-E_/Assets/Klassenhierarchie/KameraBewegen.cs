using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraBewegen : MonoBehaviour {

	public GameObject player; 
	float abstandXZ = 6f;
	float hoeheY = 4f;
	
	// Update is called once per frame
	void Update () {
		
		Quaternion fahrzeugRotationY = new Quaternion();
		
		fahrzeugRotationY.eulerAngles = new Vector3 (0, player.transform.eulerAngles.y, 0);
		
		Vector3 abstandHinterFahrzeug = fahrzeugRotationY * new Vector3 (0, 0, abstandXZ);
		
		transform.position = player.transform.position - abstandHinterFahrzeug;
		transform.position = new Vector3 (transform.position.x, transform.position.y + hoeheY, transform.position.z);
		transform.LookAt(player.transform);
		
	}
}

