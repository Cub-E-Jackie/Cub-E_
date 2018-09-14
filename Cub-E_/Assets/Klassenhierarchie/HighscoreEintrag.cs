
public class HighscoreEintrag {
	
	string vorname;
	float zeit;

	public HighscoreEintrag(string v, float z){
		
		vorname = v;
		zeit = z;
		
	}
	
	public string GetVorname(){
		
		return vorname;
	}
	
	public float GetZeit(){
		
		return zeit;
	}
	
	public string GetZeitString(){
		
		return string.Format("{0,5:0.00} sec.", zeit);
		
	}
	
	public bool GroesserAls(float neu){
		
		if ( zeit > neu )
			return true;
		else
			return false;
		
	}
}
