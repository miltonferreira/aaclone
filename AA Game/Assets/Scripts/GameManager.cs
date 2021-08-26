using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Button goBtn;

    public GameObject Pin;

    public List<GameObject> PinList;
    private int pinIndex;

    public int totalPins;

    private float pinDistance = 0.5f;
    public Vector3 temp;


    // Start is called before the first frame update
    void Start()
    {
        CreateListPins();
        getButton();
    }

    void getButton(){
        goBtn.onClick.AddListener(() => FirePin());
    }

    void FirePin(){
        PinList[pinIndex].GetComponent<pinMove>().isCanMove = true;
        pinIndex++;
    }

    void CreateListPins(){
        PinList = new List<GameObject>();

        temp = transform.position;

        for(int i = 0; i < totalPins; i++){
            PinList.Add(Instantiate(Pin, temp, Quaternion.identity) as GameObject);
            temp.y -= pinDistance;
        }
    }

    public void CreatePin(){
        Instantiate(Pin, transform.position, Quaternion.identity);
    }
    
}
