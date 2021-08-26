using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinMove : MonoBehaviour
{

    public bool isCanMove;

    public float forceY = 25;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCanMove){
            rb.velocity = new Vector2(0f, forceY);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Circle"){
            isCanMove = false;
            rb.velocity = new Vector2(0f, 0f);
            gameObject.transform.SetParent(col.transform);
        }
    }
}
