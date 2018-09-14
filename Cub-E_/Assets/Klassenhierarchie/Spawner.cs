using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //public GameObject[] enemies; //Array, fuer GameObjects, zum einfuegen der Hindernisse spaeter
    //public GameObject[] friends;
	/*public Vector3 spawnValues; //fuer Grenzen, Zeiten
	public Vector3 spawnValuesDuck;
    public float spawnWait;
	public float spawnWaitDuck;
    public float spawnMostWait; // 2
	public float spawnMostWaitDuck; // 2
    public float spawnLeastWait; // 0,5, kann entschieden werden
	public float spawnLeastWaitDuck; // 0,5, kann entschieden werden
    public int startWait;
	public int startWaitDuck;
    public bool stop;
	public bool stopDuck;*/
	
	public GameObject duckPrefab;
	public GameObject woodPrefab;
	
	
	
	public float spawnDuckFrequency = 1f;
	public float spawnWoodFrequency = 1f;
	public float spwanWoodFrequency = 1f;
	public GameObject root;
	private float timer = 0f;

   // int randEnemy; //zufaelliges objekt
	//int randDuck;

    void Start()
    {
       //StartCoroutine(WaitSpawner());  // Coroutine fuer WaitForSeconds	
		//StartCoroutine(WaitSpawnerDuck());  // Coroutine fuer WaitForSeconds	
		Update();
    }

    void Update()
    {
		GameObject duckObj;
       // spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
		//spawnWaitDuck = Random.Range(spawnLeastWaitDuck, spawnMostWaitDuck);
		timer += Time.deltaTime;
		if(timer >= spawnDuckFrequency) { 
		Vector3 rndPos = new Vector3(Random.Range(-4.5f,4.5f), 5, Random.Range(-4.5f,4.5f)); //für jede Würfelfläche, also noch 5 weitere
		
		
		
		duckObj = Instantiate(duckPrefab, rndPos, Quaternion.identity);
		duckObj.name = "Duck_Child";
		duckObj.transform.parent = root.transform;
		//duckObj.transform.position = transform.position;
		duckObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f),0);
		
		}
    }

    /*void Destroy()
    {
        if (gameObject.name == "Cube(Clone)")
        {
            Destroy(gameObject, .5f);
        }
    }
*/
    /* fuer Collision
    void OnCollisionEnter(Collision otherObj) {
        if (otherObj.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject, .5f);
         }
     }
     */
/*
    IEnumerator WaitSpawner()
    {
        // Coroutine ist eine Funktion, die die Ausfuehrung anhalten und die Steuerung an Unity uebergeben kann, faehrt dort fort wo sie im naechsten Frame unterbrochen wurde

        yield return new WaitForSeconds(startWait); //ab wann es spawnt

        while (!stop)
        { // solange stop ist nicht true wird while ausgefuehrt, moeglich waere auch (true)
			
            // muss angepasst werden, wenn wir mehr hindernisse verwenden
            randEnemy = Random.Range(0, 2); // sucht ein random enemy aus, min max in Klammern, also Nummer zwischen 0 und 1
            //Random.Range mit min und max, y nur 1 da wir keine brauchen
            // benutzt spawn position, zufaellig wo es entsteht x und z
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z)); //wo

            // bringt die Objekte in die Szene (was - random, wo, quaternion nur wenn wir eine bestimmte rotation haben
            // var clone = Instantiate(enemies[randEnemy], transform.position, transform.rotation);
            var clone = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            Destroy(clone, 5f);
            //Wartezeit bis zum naechsten spawn
            yield return new WaitForSeconds(spawnWait);
        }
    }
	
  IEnumerator WaitSpawnerDuck()
    {
        // Coroutine ist eine Funktion, die die Ausfuehrung anhalten und die Steuerung an Unity uebergeben kann, faehrt dort fort wo sie im naechsten Frame unterbrochen wurde

        yield return new WaitForSeconds(startWaitDuck); //ab wann es spawnt

        while (!stopDuck)
        { // solange stop ist nicht true wird while ausgefuehrt, moeglich waere auch (true)

            // muss angepasst werden, wenn wir mehr hindernisse verwenden
			randDuck = Random.Range(0, 2);// random für duck
            //Random.Range mit min und max, y nur 1 da wir keine brauchen
            // benutzt spawn position, zufaellig wo es entsteht x und z
            Vector3 spawnPositionDuck = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z)); //wo
			

			// bringt die Objekte in die Szene (was - random, wo, quaternion nur wenn wir eine bestimmte rotation haben
            // var clone = Instantiate(enemies[randEnemy], transform.position, transform.rotation);
    
			var duck = Instantiate(friends[randDuck], spawnPositionDuck + transform.TransformPoint(0, 0, 0), Quaternion.identity);
           //var duck = Instantiate(friends[randDuck], spawnPositionDuck + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
           
			Destroy(duck, 8f);
            //Wartezeit bis zum naechsten spawn
            yield return new WaitForSeconds(spawnWaitDuck);
        }
    }	*/
}