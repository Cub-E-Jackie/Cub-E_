﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderLevel : MonoBehaviour {
	
	int count=0;
	bool check=false;
	bool check1=false;
	bool check2=false;
	public GameObject Right;
	public GameObject Left;
	public GameObject obj1;
	public  GameObject center;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		if(check = true) {
			obj1.transform.position=Vector3.Lerp (obj1.transform.position, Right.transform.position, 1f*Time.deltaTime);
		} else if (check1 == true) {
			obj1.transform.position=Vector3.Lerp (obj1.transform.position, center.transform.position, 1f*Time.deltaTime);
		} else if (check2 == true) {
			obj1.transform.position=Vector3.Lerp (obj1.transform.position, Left.transform.position, 1f*Time.deltaTime);
		}
	}
	
	public void RightClick() {
		count++;
		if(count == 1) {
			check = true;
			check1 = true;
			check2 = true;
		} else if (count == 0){
			check=false;
			check1=true;
			check2=false;
		} else {
			count=1;
		}
	}
	public void LeftClick() {
		count--;
		if(count == 0) {
			check = false;
			check1= true;
			check2 = false;
		} else if (count == -1){
			check = false;
			check1 = false;
			check2 = true;
		} else {
			count=-1;
		}
	}
}
