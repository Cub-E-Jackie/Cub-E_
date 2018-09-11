using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
   In dieser Klasse wird alles rund um den Cube programmiert.
   - Cube wird erzeugt 
   - das Rotationsverhalten gesteuert
   - das Rotationsverhalten definiert
 */


public class CubeManager : MonoBehaviour {
	
	private int drehrichtung;
    public Vector2 textureSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	private void CubeDrehen (){

        //System.Random zufall = new System.Random();
        // Initialisieren von drehrichtung mit Zufallszahlen zwischen und einschließlich 0 und 3 (vier Möglichkeiten!)
        //drehrichtung = zufall.Next( 0,  4);
        int rnd = Random.Range(0, 4);
		
		//Auswahl der Rotationsrichtung mit SwitchCase
		switch (drehrichtung){
		
			// wenn drehrichtung == 0, 
					//dann RotationHorizontal(float richtung);
			case 0: RotationHorizontal( 90);
					break;
				
				
			// wenn drehrichtung == 1, 
				//dann RotationHorizontal(float - richtung);
			case 1: RotationHorizontal (-90);
					break;
			
			// wenn drehrichtung == 2, 
				//dann RotationVertikal(float richtung);
			case 2: RotationVertikal ( 90);
					break;
					
			// wenn drehrichtung == 3, 
				//dann RotationVertikal(float - richtung);
			case 3: RotationVertikal (-90);
					break;

            default: break;
        }
				
	}
	
	//Rotationsbewegung nach oben oder unten programmieren
	void RotationVertikal (float richtung){
	
		float geschwindigkeit = 1f;
	
		// globale Variable aktivModus auf false, zur Organisation von SpielerInput
		SpielManager.aktivModus = false;
	
		// Cube dreht sich vertikal um x Achse um übergebenen Winkel 
		transform.Rotate(new Vector3(richtung,0,0), geschwindigkeit);
		
		//alternativ???
		//transform.eulerAngles += new Vector3(0f, 0f, richtung);
		
		// Funktionsaufruf Feldwechsel() der Klasse Hindernisse
		//geht noch nicht 	Hindernisse.Feldwechsel();
		
		// globale Variable aktivModus auf true, zur Organisation von SpielerInput
		SpielManager.aktivModus = true;
		
	}
	
	//Rotationsbewegung nach links oder rechts programmieren
	void RotationHorizontal (float richtung){
	
		//float geschwindigkeit = 100f;
	
		// globale Variable aktivModus auf false, zur Organisation von SpielerInput
		SpielManager.aktivModus = false;
	
		// Cube dreht sich vertikal um y Achse um übergebenen Winkel 
		transform.Rotate(new Vector3(0,richtung,0));
		
		// Funktionsaufruf Feldwechsel() der Klasse Hindernisse
		// geht noch nicht 	Hindernisse.Feldwechsel();
		
		// globale Variable aktivModus auf true, zur Organisation von SpielerInput
		SpielManager.aktivModus = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Bewegung des Materials
		Material mat = GetComponent<Renderer>().material;
        mat.SetTextureOffset("_MainTex",  mat.GetTextureOffset("_MainTex") + textureSpeed);

	}
}
