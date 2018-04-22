using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "Player")
        {
            Transform cam = collision.transform.GetChild(0).gameObject.transform;
            cam.GetComponent<Animator>().enabled = false;
            cam.SetParent(null, true);
            collision.transform.GetComponent<BoxCollider2D>().enabled = false;
        }   
    }
}
