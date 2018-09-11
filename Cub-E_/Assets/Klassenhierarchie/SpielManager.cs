using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
   In dieser Klasse werden die organisatorischen Dinge sozusagen aus dem Hintergrund  geregelt.
   - globale Variablen zur Verwaltung des Spiels generiert und verwaltet
   - die Größen aus dem Menü werden implementiert und verwaltet
   - das Menü selbst wird gesteuert mithilfe von globalen Variablen
   - das Spiel wird beendet und gestartet
   - die Spielzeit wird hier in einer Variable gespeichert und verwaltet

*/


public class SpielManager : MonoBehaviour {
	
	static public bool aktivModus;

	// Use this for initialization
	void Start () {
		
		aktivModus = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
