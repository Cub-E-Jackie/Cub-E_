using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnWait;
    public float startWait;
    public bool stop;

    public GameObject duckPrefab;
    public GameObject duckPrefab1;
    public GameObject duckPrefab4;
    public GameObject duckPrefab5;
    public GameObject woodPrefab;
    public GameObject woodPrefab1;
    public GameObject woodPrefab4;
    public GameObject woodPrefab5;
    public GameObject stonePrefab;
    public GameObject stonePrefab1;
    public GameObject stonePrefab4;
    public GameObject stonePrefab5;

    public GameObject root;

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
    GameObject duckObj4;
    GameObject duckObj5;
    GameObject woodObj;
    GameObject woodObj1;
    GameObject woodObj4;
    GameObject woodObj5;
    GameObject stoneObj;
    GameObject stoneObj1;
    GameObject stoneObj4;
    GameObject stoneObj5;

    IEnumerator WaitSpawnerDuck()
    {

        yield return new WaitForSeconds(startWait); //ab wann es spawnt

        while (!stop)
        {
            Vector3 rndPos = new Vector3(Random.Range(-4.5f, 4.5f), 5, Random.Range(-4.5f, 4.5f)); // duckObj
            Vector3 rndPos1 = new Vector3(Random.Range(-4.5f, 4.5f), -5, Random.Range(-4.5f, 4.5f)); // duckObj1
            Vector3 rndPos4 = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 5); // duckObj4
            Vector3 rndPos5 = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), -5); // duckObj5

            #region Entchen

            duckObj = Instantiate(duckPrefab, rndPos, Quaternion.identity);
            duckObj.name = "Duck_Child";
            duckObj.transform.parent = root.transform;
            duckObj.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(duckObj, 4f);

            duckObj1 = Instantiate(duckPrefab1, rndPos1, Quaternion.identity);
            duckObj1.name = "Duck_Child1";
            duckObj1.transform.parent = root.transform;
            duckObj1.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            Destroy(duckObj1, 4f);

            duckObj4 = Instantiate(duckPrefab4, rndPos4, Quaternion.identity);
            duckObj4.name = "Duck_Child4";
            duckObj4.transform.parent = root.transform;
            duckObj4.transform.eulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
            Destroy(duckObj4, 4f);

            duckObj5 = Instantiate(duckPrefab5, rndPos5, Quaternion.identity);
            duckObj5.name = "Duck_Child5";
            duckObj5.transform.parent = root.transform;
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
            Vector3 rndPosw4 = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 5); // duckObj4
            Vector3 rndPosw5 = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), -5); // duckObj5

            #region Wood
            woodObj = Instantiate(woodPrefab, rndPosw, Quaternion.identity);
            woodObj.name = "Wood/Holz";
            woodObj.transform.parent = root.transform;
            Destroy(woodObj, 4f);

            woodObj1 = Instantiate(woodPrefab1, rndPosw1, Quaternion.identity);
            woodObj1.name = "Wood/Holz1";
            woodObj1.transform.parent = root.transform;
            Destroy(woodObj1, 4f);

            woodObj4 = Instantiate(woodPrefab4, rndPosw4, Quaternion.identity);
            woodObj4.name = "Wood/Holz4";
            woodObj4.transform.parent = root.transform;
            Destroy(woodObj4, 4f);

            woodObj5 = Instantiate(woodPrefab5, rndPosw5, Quaternion.identity);
            woodObj5.name = "Wood/Holz5";
            woodObj5.transform.parent = root.transform;
            Destroy(woodObj5, 4f);

            #endregion

            yield return new WaitForSeconds(spawnWait);
        }
      
    }

    IEnumerator WaitSpawnerStone()
    {
        yield return new WaitForSeconds(startWait); //ab wann es spawnt

        while (!stop)
        {
            Vector3 rndPoss = new Vector3(Random.Range(-4f, 4f), 5.3f, Random.Range(-4f, 4f)); // duckObj
            Vector3 rndPoss1 = new Vector3(Random.Range(-4f, 4f), -5.3f, Random.Range(-4f, 4f)); // duckObj1
            Vector3 rndPoss4 = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 5); // duckObj4
            Vector3 rndPoss5 = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), -5); // duckObj5

            stoneObj = Instantiate(stonePrefab, rndPoss, Quaternion.identity);
            stoneObj.name = "Stone";
            stoneObj.transform.parent = root.transform;
            Destroy(stoneObj, 4f);

            stoneObj1 = Instantiate(stonePrefab1, rndPoss1, Quaternion.identity);
            stoneObj1.name = "Stone1";
            stoneObj1.transform.parent = root.transform;
            stoneObj1.transform.eulerAngles = new Vector3(180f, 0f, 0f);
            Destroy(stoneObj1, 4f);

            stoneObj4 = Instantiate(stonePrefab4, rndPoss4, Quaternion.identity);
            stoneObj4.name = "Stone4";
            stoneObj4.transform.parent = root.transform;
            Destroy(stoneObj4, 4f);

            stoneObj5 = Instantiate(stonePrefab5, rndPoss5, Quaternion.identity);
            stoneObj5.name = "Stone5";
            stoneObj5.transform.parent = root.transform;
            Destroy(stoneObj5, 4f);

            yield return new WaitForSeconds(spawnWait);
        }
    }


}