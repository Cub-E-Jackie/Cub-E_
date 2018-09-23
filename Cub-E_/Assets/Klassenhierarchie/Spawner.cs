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
    public float spawnWait;
    public int startWait;
    public bool stop;

    public GameObject duckPrefab;
    public GameObject duckPrefab1;
    public GameObject duckPrefab2;
    public GameObject duckPrefab3;
    public GameObject duckPrefab4;
    public GameObject duckPrefab5;
    public GameObject woodPrefab;
    public GameObject woodPrefab1;
    public GameObject woodPrefab2;
    public GameObject woodPrefab3;
    public GameObject woodPrefab4;
    public GameObject woodPrefab5;
    public GameObject stonePrefab;
    public GameObject stonePrefab1;
    public GameObject stonePrefab2;
    public GameObject stonePrefab3;
    public GameObject stonePrefab4;
    public GameObject stonePrefab5;

    public GameObject root;
    //private float timer = 6f;

    // int randEnemy; //zufaelliges objekt
    //int randDuck;

    void Start()
    {
        //StartCoroutine(WaitSpawner());  // Coroutine fuer WaitForSeconds	
        StartCoroutine(WaitSpawnerDuck()); // Coroutine fuer WaitForSeconds	
                                           //Update();
        StartCoroutine(WaitSpawnerWood());

        StartCoroutine(WaitSpawnerStone());
    }

    void Update()
    {

    }
    //if(timer <= spawnDuckFrequency) { 

    GameObject duckObj; //oben
    GameObject duckObj1; //unten
    GameObject duckObj2;
    GameObject duckObj3;
    GameObject duckObj4;
    GameObject duckObj5;
    GameObject woodObj;
    GameObject woodObj1;
    GameObject woodObj2;
    GameObject woodObj3;
    GameObject woodObj4;
    GameObject woodObj5;
    GameObject stoneObj;
    GameObject stoneObj1;
    GameObject stoneObj2;
    GameObject stoneObj3;
    GameObject stoneObj4;
    GameObject stoneObj5;

    // spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    //spawnWaitDuck = Random.Range(spawnLeastWaitDuck, spawnMostWaitDuck);
    //timer += Time.deltaTime;



    IEnumerator WaitSpawnerDuck()
    {
        yield return new WaitForSeconds(startWait); //ab wann es spawnt

        while (!stop)
        {
            Vector3 rndPos = new Vector3(Random.Range(-4.5f, 4.5f), 5, Random.Range(-4.5f, 4.5f)); // duckObj
            Vector3 rndPos1 = new Vector3(Random.Range(-4.5f, 4.5f), -5, Random.Range(-4.5f, 4.5f)); // duckObj1
            Vector3 rndPos2 = new Vector3(5, Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f)); // duckObj2
            Vector3 rndPos3 = new Vector3(-5, Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f)); // duckObj3
            Vector3 rndPos4 = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 5); // duckObj4
            Vector3 rndPos5 = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), -5); // duckObj5

            #region Entchen

            duckObj = Instantiate(duckPrefab, rndPos, Quaternion.identity);
            duckObj.name = "Duck_Child";
            duckObj.transform.parent = root.transform;
            //duckObj.transform.position = transform.position;
            duckObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(duckObj, 4f);

            duckObj1 = Instantiate(duckPrefab1, rndPos1, Quaternion.identity);
            duckObj1.name = "Duck_Child1";
            duckObj1.transform.parent = root.transform;
            //duckObj1.transform.position = transform.position;
            duckObj1.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(duckObj1, 4f);

            duckObj2 = Instantiate(duckPrefab2, rndPos2, Quaternion.identity);
            duckObj2.name = "Duck_Child2";
            duckObj2.transform.parent = root.transform;
            //duckObj2.transform.position = transform.position;
            duckObj2.transform.eulerAngles = new Vector3(Random.Range(0f, 360f), 0, 0);
            Destroy(duckObj2, 4f);

            duckObj3 = Instantiate(duckPrefab3, rndPos3, Quaternion.identity);
            duckObj3.name = "Duck_Child3";
            duckObj3.transform.parent = root.transform;
            //duckObj3.transform.position = transform.position;
            duckObj3.transform.eulerAngles = new Vector3(Random.Range(0f, 360f), 0, 0);
            Destroy(duckObj3, 4f);

            duckObj4 = Instantiate(duckPrefab4, rndPos4, Quaternion.identity);
            duckObj4.name = "Duck_Child4";
            duckObj4.transform.parent = root.transform;
            //duckObj4.transform.position = transform.position;
            duckObj4.transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            Destroy(duckObj4, 4f);

            duckObj5 = Instantiate(duckPrefab5, rndPos5, Quaternion.identity);
            duckObj5.name = "Duck_Child5";
            duckObj5.transform.parent = root.transform;
            //duckObj5.transform.position = transform.position;
            duckObj5.transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            Destroy(duckObj5, 4f);
            #endregion


            yield return new WaitForSeconds(spawnWait);
        }
    }

    IEnumerator WaitSpawnerWood()
    {
        yield return new WaitForSeconds(startWait); //ab wann es spawnt

        while (!stop)
        {
            Vector3 rndPosw = new Vector3(Random.Range(-4f, 4f), 4.8f, Random.Range(-4f, 4f)); // duckObj
            Vector3 rndPosw1 = new Vector3(Random.Range(-4f, 4f), -5.3f, Random.Range(-4f, 4f)); // duckObj1
            Vector3 rndPosw2 = new Vector3(5, Random.Range(-4f, 4f), Random.Range(-4f, 4f)); // duckObj2
            Vector3 rndPosw3 = new Vector3(-5, Random.Range(-4f, 4f), Random.Range(-4f, 4f)); // duckObj3
            Vector3 rndPosw4 = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 5); // duckObj4
            Vector3 rndPosw5 = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), -5); // duckObj5

            #region Wood
            woodObj = Instantiate(woodPrefab, rndPosw, Quaternion.identity);
            woodObj.name = "Wood/Holz";
            woodObj.transform.parent = root.transform;
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(woodObj, 4f);

            woodObj1 = Instantiate(woodPrefab1, rndPosw1, Quaternion.identity);
            woodObj1.name = "Wood/Holz1";
            woodObj1.transform.parent = root.transform;
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(woodObj1, 4f);

            woodObj2 = Instantiate(woodPrefab2, rndPosw2, Quaternion.identity);
            woodObj2.name = "Wood/Holz2";
            woodObj2.transform.parent = root.transform;
            woodObj2.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(woodObj2, 4f);

            woodObj3 = Instantiate(woodPrefab3, rndPosw3, Quaternion.identity);
            woodObj3.name = "Wood/Holz3";
            woodObj3.transform.parent = root.transform;
            woodObj3.transform.eulerAngles = new Vector3(0f, 90f, 0f);
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(woodObj3, 4f);

            woodObj4 = Instantiate(woodPrefab4, rndPosw4, Quaternion.identity);
            woodObj4.name = "Wood/Holz4";
            woodObj4.transform.parent = root.transform;
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(woodObj4, 4f);

            woodObj5 = Instantiate(woodPrefab5, rndPosw5, Quaternion.identity);
            woodObj5.name = "Wood/Holz5";
            woodObj5.transform.parent = root.transform;
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(woodObj5, 4f);

            #endregion

            yield return new WaitForSeconds(spawnWait);
        }

        #region alte
        /*void Destroy()
        {
            if (gameObject.name == "Cube(Clone)")
            {
                Destroy(gameObject, 3f);
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
        #endregion
    }
    IEnumerator WaitSpawnerStone()
    {
        yield return new WaitForSeconds(startWait); //ab wann es spawnt

        while (!stop)
        {
            Vector3 rndPoss = new Vector3(Random.Range(-4f, 4f), 5.3f, Random.Range(-4f, 4f)); // duckObj
            Vector3 rndPoss1 = new Vector3(Random.Range(-4f, 4f), -5.3f, Random.Range(-4f, 4f)); // duckObj1
            Vector3 rndPoss2 = new Vector3(5, Random.Range(-4f, 4f), Random.Range(-4f, 4f)); // duckObj2
            Vector3 rndPoss3 = new Vector3(-5, Random.Range(-4f, 4f), Random.Range(-4f, 4f)); // duckObj3
            Vector3 rndPoss4 = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 5); // duckObj4
            Vector3 rndPoss5 = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), -5); // duckObj5

            stoneObj = Instantiate(stonePrefab, rndPoss, Quaternion.identity);
            stoneObj.name = "Stone";
            stoneObj.transform.parent = root.transform;
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(stoneObj, 4f);

            stoneObj1 = Instantiate(stonePrefab1, rndPoss1, Quaternion.identity);
            stoneObj1.name = "Stone1";
            stoneObj1.transform.parent = root.transform;
            stoneObj1.transform.eulerAngles = new Vector3(180f, 0f, 0f);
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(stoneObj1, 4f);

            stoneObj2 = Instantiate(stonePrefab2, rndPoss2, Quaternion.identity);
            stoneObj2.name = "Stone2";
            stoneObj2.transform.parent = root.transform;
            //stoneObj.transform.eulerAngles = new Vector3(90f, 90f, 0f);
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(stoneObj2, 4f);

            stoneObj3 = Instantiate(stonePrefab3, rndPoss3, Quaternion.identity);
            stoneObj3.name = "Stone3";
            stoneObj3.transform.parent = root.transform;
            //stoneObj.transform.eulerAngles = new Vector3(-90f, 90f, 0f);
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(stoneObj3, 4f);

            stoneObj4 = Instantiate(stonePrefab4, rndPoss4, Quaternion.identity);
            stoneObj4.name = "Stone4";
            stoneObj4.transform.parent = root.transform;
            //stoneObj.transform.eulerAngles = new Vector3(-90f, 180f, 0f);
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(stoneObj4, 4f);

            stoneObj5 = Instantiate(stonePrefab5, rndPoss5, Quaternion.identity);
            stoneObj5.name = "Stone5";
            stoneObj5.transform.parent = root.transform;
            //stoneObj.transform.eulerAngles = new Vector3(90f, 180f, 0f);
            //duckObj.transform.position = transform.position;
            //woodObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(stoneObj5, 4f);

            yield return new WaitForSeconds(spawnWait);
        }
    }


}