using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    public static ClickController instance;
    void Awake(){
        instance=this;
    }

    public float autoClickTime=1f;
    public float autoClickTimer=0f;
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Click();
        }
        autoClickTimer+=Time.deltaTime;
        if(autoClickTimer>=autoClickTime){
            Click();
            autoClickTimer=0f;
        }
    }

    public void Click(){
        
        if(Random.Range(0,1)>(1-Model.instance.CriticalPercentage)){
            Model.instance.ChangeMoney(Model.instance.MoneyPerClick*Model.instance.CriticalMultiplier);
            ObjectPool.instance.CreateNumberAtRandomPosition(Model.instance.MoneyPerClick*Model.instance.CriticalMultiplier);
        }else{
            Model.instance.ChangeMoney(Model.instance.MoneyPerClick);
            ObjectPool.instance.CreateNumberAtRandomPosition(Model.instance.MoneyPerClick);
        }
        UpdateUI();
    }

    public void UpdateUI(){
        UIController.instance.UpdateUI();   
    }
}
