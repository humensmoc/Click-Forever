using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodStack : MonoBehaviour
{
    public float amount;
    public float maxAmount;
    

    public void Init(float amount){
        this.amount=amount;
        this.maxAmount=amount;
    }

    void Update()
    {
        UpdateScale();
    }

    public void UpdateScale(){
        float rate=amount/maxAmount;
        Debug.Log(rate);
        transform.localScale=new Vector3(rate,rate,rate);
    }

    public void GetBite(Ant ant){
        amount-=ant.biteAmount;
        GameObject foodObject=GenerateFood(ant.biteAmount).gameObject;
        foodObject.GetComponent<Food>().SetCarrier(ant);
        ant.foodCarried=foodObject;

        if(amount<=0){
            Dead();
        }
    }

    public Food GenerateFood(float amount){
        GameObject foodObject=Instantiate(Resources.Load<GameObject>("Prefabs/Food"), transform.position, Quaternion.identity);
        Food food=foodObject.GetComponent<Food>();
        food.Init(transform.position, amount);
        return food;
    }

    public void Dead(){
        foreach(Ant ant in Home.instance.ants){
            if(ant.target==this.gameObject){
                ant.SetTarget(Home.instance.GetAntTarget(ant));
            }
        }

        FoodController.instance.foodStacks.Remove(this);
        Destroy(gameObject);    
    }
    
}
