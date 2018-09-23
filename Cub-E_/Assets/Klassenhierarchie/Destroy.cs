using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            anim.enabled = true;
            
        }
    } 
}


/*private GameObject Objekt;
void OnTriggerEnter(Collider collision)
{
    if (collision.gameObject.tag == "Player")
    {
        // Objekt.animation.Play("animation");
        GetComponent<Animation>().Play("Stone");
    }
    Destroy(collision.gameObject);
} */
