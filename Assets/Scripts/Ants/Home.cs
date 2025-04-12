using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Home : MonoBehaviour
{
    public static Home instance;
    private void Awake()
    {
        instance = this;
    }

    public List<Ant> ants = new List<Ant>();
    public float antLifeTime;
    private float interval;
    public float maxInterval=0.2f;
    public int nearestPossibility;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            GenerateAnts();
        }

        interval-=Time.deltaTime;
        if(interval<=0){
            GenerateAnts();
            interval=maxInterval;
        }



    }

    public void GenerateAnts()
    {
        GameObject antObject=Instantiate(Resources.Load<GameObject>("Prefabs/Ant"), Ground.instance.transform);
        antObject.transform.position=transform.position;
        Ant ant=antObject.GetComponent<Ant>();

        GameObject target=GetAntTarget(ant);

        ant.Init(1, 1, 1, target, antLifeTime);

        ants.Add(ant);
    }

    public GameObject GetAntTarget(Ant ant){
        if(Random.Range(0,10)>nearestPossibility){
            if(FoodController.instance.lostFoods.Count>0){
                GameObject lostFood=null;
                foreach(Food f in FoodController.instance.lostFoods){
                    if(lostFood==null){
                        lostFood=f.gameObject;
                    }
                    else{
                        if(Vector3.Distance(ant.transform.position, f.transform.position)<Vector3.Distance(ant.transform.position, lostFood.transform.position)){
                            lostFood=f.gameObject;
                        }   
                    }
                }
                return lostFood;
            }
            else{
                GameObject foodStack=null;
                foreach(FoodStack fs in FoodController.instance.foodStacks){
                    if(foodStack==null){
                        foodStack=fs.gameObject;
                    }
                    else{
                        if(Vector3.Distance(ant.transform.position, fs.transform.position)<Vector3.Distance(ant.transform.position, foodStack.transform.position)){
                            foodStack=fs.gameObject;
                        }
                    }
                }
                return foodStack;
            }
        }else{
            if(FoodController.instance.lostFoods.Count>0){
                return FoodController.instance.lostFoods[Random.Range(0,FoodController.instance.lostFoods.Count)].gameObject;
            }else{
                return FoodController.instance.foodStacks[Random.Range(0,FoodController.instance.foodStacks.Count)].gameObject;
            }
        }

        
    }

    
}
