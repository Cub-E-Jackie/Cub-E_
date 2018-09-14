using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anzeige : MonoBehaviour {

	List<HighscoreEintrag> liste;
	
	public Text vornameAnzeige;
	public Text zeitAnzeige;
	
	public InputField vornameEingabe;
	
	public Toggle anzeigeSchalter;
	
	void Start () {
		
		liste = new List<HighscoreEintrag>();
		ListeFuellen();
		
	}
	
	void ListeFuellen(){
		
		for( int i = 0; i < 10; i++){
			
			if(PlayerPrefs.HasKey("vorname" + i)){
				
				string vorname = PlayerPrefs.GetString("vorname" + i);
				float zeit = PlayerPrefs.GetFloat("zeit" + i);
				HighscoreEintrag eintrag = new HighscoreEintrag(vorname, zeit);
				liste.Add(eintrag);
				
			}
			
			else
				break;
		
		}
		
		ListeAnzeigen();
	}
	
	void ListeAnzeigen(){
		
		string vornameAusgabe = "";
		string zeitAusgabe = "";
		
		for ( int i = 0; i < liste.Count && i < 10; i++){
			
			vornameAusgabe += liste[i].GetVorname() + "\n";
			zeitAusgabe += liste[i].GetZeitString() + "\n";
		
		}
		
		vornameAnzeige.text = vornameAusgabe;
		zeitAnzeige.text = zeitAusgabe;
	}
	
	public void NeuerEintragHinzu(){
		
		HighscoreEintrag neuerEintrag = ZufallsEintrag();
		
		bool eingefuegt = false;
		for( int i = 0; i < liste.Count; i++){
			
			if ( liste[i].GroesserAls(neuerEintrag.GetZeit())){
				
				liste.Insert(i, neuerEintrag);
				eingefuegt = true;
				break;
			}
		}
		
		if ( !eingefuegt )
			liste.Add(neuerEintrag);
		
		ListeAnzeigen();
		ListeSpeichern();
	}
	
	HighscoreEintrag ZufallsEintrag(){
		
		string vorname = "NN";
		string eingabe = vornameEingabe.text;
		
		if( eingabe != ""){
			
			if (eingabe.Length >= 10)			
			eingabe = eingabe.Substring(0,10);
		
		vorname = eingabe;
		
		}	
	
		float zeit = Random.Range (6.0f, 12.0f);
		HighscoreEintrag neuerEintrag = new HighscoreEintrag (vorname, zeit);
		
		return neuerEintrag;
	}
	
	void ListeSpeichern(){
		
		for ( int i = 0; i < liste.Count && i < 10; i++){
			
			PlayerPrefs.SetString("vorname" + i, liste[i].GetVorname());
			PlayerPrefs.SetFloat("zeit" + i, liste[i].GetZeit());
		}
	}
	
	public void AllesLoeschen(){
		
		vornameAnzeige.text = "";
		zeitAnzeige.text = "";
		
		liste.Clear();
		PlayerPrefs.DeleteAll();
		
	}
	
	public void AnzeigeSchalterGeklickt(){
		
		if(anzeigeSchalter.isOn)
			ListeAnzeigen();
		
		else{
			
			vornameAnzeige.text = "";
			zeitAnzeige.text = "";
			
		}
	}
}
