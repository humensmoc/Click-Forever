using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public enum TargetType{

    Food,
    FoodStack,
    Home
}

public class Ant : MonoBehaviour
{
    public float maxAmount;
    public float  biteAmount;
    public float speed;
    public float lifeTime;
    public float maxLifeTime;
    public GameObject target;
    public GameObject foodPlace;
    public GameObject foodCarried;
    public TargetType targetType;

    public Color startColor,endColor;
    public Gradient colorGradient;
    public SpriteRenderer bodySprite;

    public void Init(float maxAmount, float biteAmount, float speed,  GameObject target, float lifeTime){
        this.maxAmount=maxAmount;
        this.biteAmount=biteAmount;
        this.speed=speed;
        this.lifeTime=lifeTime;
        this.maxLifeTime=lifeTime;

        SetTarget(target);
    }

    public void Update(){
        Move();
        CheckLife();
        UpdateBodyColor();
    }

    public void Move(){
        if(target!=null){
            MoveToTarget(target.transform.position);
            if(CheckIfArriveTarget(target.transform.position)){
                ArriveTarget(targetType);
            }
        }else{
            SetTarget(Home.instance.gameObject);
        }
    }

    public void CheckLife(){
        lifeTime-=Time.deltaTime;
        if(lifeTime<=0){
            Dead();
        }
    }

    public void UpdateBodyColor(){
        float rate=lifeTime/maxLifeTime;
        bodySprite.color=new Color(
            math.lerp(endColor.r,startColor.r,rate),
            math.lerp(endColor.g,startColor.g,rate),
            math.lerp(endColor.b,startColor.b,rate),
            math.lerp(endColor.a,startColor.a,rate)
        );
    }

    public bool CheckIfArriveTarget(Vector3 target){
        return Vector3.Distance(transform.position, target)<0.1f;
    }

    public void ArriveTarget(TargetType targetType){
        switch(targetType){
            case TargetType.Food:
                target.GetComponent<Food>().SetCarrier(this);
                SetTarget(Home.instance.gameObject);
                break;

            case TargetType.FoodStack:
                if(target != null){
                    Bite(target.GetComponent<FoodStack>());
                }
                SetTarget(Home.instance.gameObject);
                break;

            case TargetType.Home:
                SetTarget(FoodController.instance.foodStacks[0].gameObject);
                Destroy(foodCarried);
                foodCarried=null;
                break;
        }
    }

    public void Bite(FoodStack foodStack){
        foodStack.GetBite(this);
    }
    
    public void Dead(){
        Home.instance.ants.Remove(this);
        if(foodCarried!=null){
            foodCarried.GetComponent<Food>().Lost();
        }
        Destroy(gameObject);
        
    }

    public void SetTarget(GameObject target){
        this.target=target;
        if(target.GetComponent<FoodStack>()!=null){
            targetType=TargetType.FoodStack;
        }
        else if(target.GetComponent<Food>()!=null){
            targetType=TargetType.Food;
        }
        else if(target.GetComponent<Home>()!=null){
            targetType=TargetType.Home;
        }
        
    }

    public void MoveToTarget(Vector3 target){
        transform.position=Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }
    
}

    

