using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Button goBtn;

    public GameObject Pin;

    public List<GameObject> PinList;
    private int pinIndex;

    public int totalPins;

    private float pinDistance = 0.3f;
    public Vector3 temp;

    public float _y;
    private int countList = 0;

    public Text pinText;
    public static int pinsCount;
    public Button btnRestart;


    // Start is called before the first frame update
    void Start()
    {
        CreateListPins();
        getButton();

        btnRestart.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
            pinsCount = 0;
        });
    }

    void Update() {
        pinText.text = pinsCount.ToString();

        if(Time.timeScale == 0){
            btnRestart.gameObject.SetActive(true);
        }
    }

    void getButton(){
        goBtn.onClick.AddListener(() => FirePin());
    }

    void FirePin(){

        if(Time.timeScale == 0)
            return;

        PinList[pinIndex].GetComponent<pinMove>().isCanMove = true;

        pinIndex++;
        countList++;

        for(int i=countList; i<PinList.Count; i++){

            if(!PinList[i].GetComponent<pinMove>().isCanMove){
                _y = PinList[i].transform.position.y;
                _y += pinDistance;

                PinList[i].transform.position = new Vector3(transform.position.x, _y, transform.position.z);
            }

        }

        StartCoroutine(CreatePin());
    }

    IEnumerator CreatePin(){
        yield return new WaitForSeconds(0.05f);
        PinList.Add(Instantiate(Pin, temp, Quaternion.identity) as GameObject);
    }

    void CreateListPins(){
        PinList = new List<GameObject>();

        temp = transform.position;

        for(int i = 0; i <= totalPins-1; i++){
            PinList.Add(Instantiate(Pin, temp, Quaternion.identity) as GameObject);
            if(i == totalPins-1){
                
            }else{
                temp.y -= pinDistance;
            }
        }
    }

    
    
}
