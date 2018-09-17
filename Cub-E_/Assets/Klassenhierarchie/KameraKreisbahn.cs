using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKreisbahn : MonoBehaviour {
	
	public GameObject dreh;
	public Vector3 abstandHinterEnte;
	public float abstandXZ = 6f;
	public float hoeheY = 4f;
	
		
		
	// Update is called once per frame
	void Update () {
//		
//		Quaternion fahrzeugRotationY = new Quaternion();
//		
//		fahrzeugRotationY.eulerAngles = new Vector3 (0, dreh.transform.eulerAngles.y, 0);
//		
//		abstandHinterEnte = fahrzeugRotationY * new Vector3 (0, 0, abstandXZ);
//		
//		transform.position = dreh.transform.position - abstandHinterEnte;
//		transform.position = new Vector3 (transform.position.x, transform.position.y + hoeheY, transform.position.z);
		transform.LookAt(dreh.transform);
	}
}
