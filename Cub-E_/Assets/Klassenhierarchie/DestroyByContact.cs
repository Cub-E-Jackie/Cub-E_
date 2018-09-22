﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(gameObject);

        FindObjectOfType<AudioManager>().Play("Collision");
    }
}