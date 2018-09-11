using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] enemies; //Array, fuer GameObjects, zum einfuegen der Hindernisse spaeter
    public Vector3 spawnValues; //fuer Grenzen, Zeiten
    public float spawnWait;
    public float spawnMostWait; // 2
    public float spawnLeastWait; // 0,5, kann entschieden werden
    public int startWait;
    public bool stop;

    int randEnemy; //zufaelliges objekt

    void Start()
    {
        StartCoroutine(WaitSpawner());  // Coroutine fuer WaitForSeconds	
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

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
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z)); //wo

            // bringt die Objekte in die Szene (was - random, wo, quaternion nur wenn wir eine bestimmte rotation haben
            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            //Wartezeit bis zum naechsten spawn
            yield return new WaitForSeconds(spawnWait);
        }
    }
}