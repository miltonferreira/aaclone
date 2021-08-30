using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Head"){
            Time.timeScale = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D col) {
        if(col.gameObject.tag == "Head"){
            Time.timeScale = 0;
        }
    }
}
