using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Vector3 position;
    public float amount;
    public Ant carrier;

    void Update()
    {
        if(carrier!=null){
            this.transform.position=carrier.foodPlace.transform.position;
        }
    }

    public void Init(Vector3 position, float amount){
        this.position=position;
        this.amount=amount;
    }

    public void Lost(){
        this.transform.SetParent(Ground.instance.transform);
        FoodController.instance.lostFoods.Add(this);

        Debug.Log("LostFood");
    }

    public void SetCarrier(Ant ant){
        
        if(FoodController.instance.lostFoods.Contains(this)){
            FoodController.instance.lostFoods.Remove(this);
        }

        foreach(Ant a in Home.instance.ants){
            if(a.target==this.gameObject){
                a.SetTarget(Home.instance.GetAntTarget(a));
            }
        }

        carrier=ant;
        ant.foodCarried=this.gameObject;
    }
}
