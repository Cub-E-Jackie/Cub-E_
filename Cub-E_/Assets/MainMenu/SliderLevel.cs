using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderLevel : MonoBehaviour {
	
	int count=0;
	bool check=false;
	bool check1=false;
	public GameObject Right; //rechts kennzeichnen
	public GameObject Left; //links kennzeichnen
	public GameObject obj1; //Hauptobjekt1
	public GameObject obj2; //Hauptobjekt2
	public  GameObject center; //um mitte zu kennzeichnen
	
	
	// Update: mit true für den Slider,Lerp(position von Hauptobjekt, nach rechts mitte oder links, zeit)
	public void Update () {
		if(check == true) {
			obj1.transform.position=Vector3.Lerp (obj1.transform.position, Right.transform.position, 2f*Time.deltaTime);
			obj2.transform.position=Vector3.Lerp (obj2.transform.position, center.transform.position, 2f*Time.deltaTime);
			
		} else if (check1 == true) {
			obj1.transform.position=Vector3.Lerp (obj1.transform.position, center.transform.position, 2f*Time.deltaTime);
			obj2.transform.position=Vector3.Lerp (obj2.transform.position, Left.transform.position, 2f*Time.deltaTime);
		} 
		

	}
	
	//drückt man auf rechten Button
	public void RightClick() {
		count++; //zählt
		if(count == 1) { //wenn einmal, dann alles true gestellt und durch Update Bewegung
			check = true;
			check1 = true;
		} else if (count == 0){ //wenn null mal, dann zurück auf center
			check=false;
			check1=true;
		} else {
			count=1;
		}
	}
	
	//drückt man auf linken Button
	public void LeftClick() {
		count--;//minus gezählt
		if(count == 0) { //wenn null zurück auf center
			check = false;
			check1= true;
		} else if (count == -1){ //wenn minus eins, dann nach links
			check = false;
			check1 = false;
		} else {
			count=-1;
		}
	}
}
