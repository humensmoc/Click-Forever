using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    List<GameObject> activeNumbers=new List<GameObject>();
    List<GameObject> inactiveNumbers=new List<GameObject>();
    public float speed;
    public Transform UpLeft;
    public Transform UpRight;
    public Transform Down;

    void Awake(){
        instance=this;
    }

    void Update()
    {
        UpdateNumbers();
    }

    public GameObject GetNumber(){
        if(inactiveNumbers.Count>0){
            GameObject numberObject=inactiveNumbers[0];
            inactiveNumbers.RemoveAt(0);
            activeNumbers.Add(numberObject);
            numberObject.SetActive(true);
            return numberObject;
        }
        else{
            GameObject numberObject=Instantiate(Resources.Load<GameObject>("Prefabs/Number"));
            activeNumbers.Add(numberObject);
            return numberObject;
        }
    }

    public void ReturnNumber(GameObject number){
        // number.GetComponentInChildren<TMP_Text>().color=Color.red;
        number.SetActive(false);
        activeNumbers.Remove(number);
        inactiveNumbers.Add(number);
    }

    public void CreateNumber(float number, Vector3 position){
        GameObject numberObject=GetNumber();
        numberObject.transform.position=position;
        numberObject.GetComponentInChildren<TMP_Text>().text=number.ToString();

        if(number!=Model.instance.MoneyPerClick){
            // numberObject.GetComponentInChildren<TMP_Text>().color=Color.black;
        }

    }

    public void CreateNumberAtRandomPosition(float number){
        Vector3 randomPosition=new Vector3(Random.Range(UpLeft.position.x, UpRight.position.x), Random.Range(UpLeft.position.y, UpRight.position.y), 0);
        CreateNumber(number, randomPosition);
    }

    public void UpdateNumbers(){
        List<GameObject> numbersToRemove = new List<GameObject>();
        
        foreach(GameObject number in activeNumbers){
            number.transform.position = new Vector3(number.transform.position.x, number.transform.position.y-speed*Time.deltaTime, number.transform.position.z);
            if(number.transform.position.y < Down.position.y){
                numbersToRemove.Add(number);
            }
        }

        foreach(GameObject number in numbersToRemove){
            ReturnNumber(number);
        }
    }
}
