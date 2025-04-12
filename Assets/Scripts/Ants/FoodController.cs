using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public static FoodController instance;
    void Awake(){
        instance=this;
    }

    public float foodGenerateRange=3;
    private float interval;
    public float maxInterval;

    public int maxFoodStack=10;

    public int amountOfFoodStack;

    public List<FoodStack> foodStacks = new List<FoodStack>();
    public List<Food> lostFoods = new List<Food>();
    

    void Start(){
        GenerateFoodStack();
        GenerateFoodStack();
        GenerateFoodStack();
    }

    void Update(){
        interval-=Time.deltaTime;
        if(interval<=0){
            if(foodStacks.Count<maxFoodStack){
                GenerateFoodStack();
            }
            maxInterval=1;
        }
    }

    public void GenerateFoodStack(){
        GameObject foodStack=Instantiate(Resources.Load<GameObject>("Prefabs/FoodStack"));
        FoodStack foodStackScript=foodStack.GetComponent<FoodStack>();
        foodStackScript.Init(amountOfFoodStack);
        foodStacks.Add(foodStackScript);
        foodStack.transform.position=new Vector3(Random.Range(-foodGenerateRange, foodGenerateRange), Random.Range(-foodGenerateRange, foodGenerateRange), 0);
    }


}