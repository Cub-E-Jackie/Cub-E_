using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleConstantMove : MonoBehaviour
{

    gameManager GameManager;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController"); // SpawnerManager ist getagged
        GameManager = gameController.GetComponent<gameManager>(); // addresiert an Eigenschaften des anderen Skripts
    }


    void Update()
    {
        transform.Translate(GameManager.moveVector * GameManager.moveSpeed * Time.deltaTime); // fuer die Bewegung zustaendig
    }
}