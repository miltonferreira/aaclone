using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleRotation : MonoBehaviour
{

    public float speed;     // velocidade de rotação do circulo
    public float angle;     // rotação do circulo

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(RandomRotation());
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    void Rotation(){

        angle = transform.eulerAngles.z;
        angle += speed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0f,0f, angle));

    }

    IEnumerator RandomRotation(){
        yield return new WaitForSeconds(2f);

        if(Random.Range(0,2) > 0){
            speed = -Random.Range(50, 200);
        } else {
            speed = Random.Range(50, 200);
        }

        StartCoroutine(RandomRotation());

    }
    
}
