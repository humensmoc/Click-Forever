using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public static Model instance;

    void Awake()
    {
        instance=this;
    }

    private float money=0;
    private int clickPower=1;
    private int clickPowerLevel=1;
    private int prestigePoints=0;
    private int convertPrice=1000;
    private int powerLevel=1;
    private int powerLevelStorage=0;
    private int percentLevel=1;
    private int percentLevelStorage=0;
    private int priceLevel=1;
    private int priceLevelStorage=0;
    private int criticalLevel=1;
    private int criticalLevelStorage=0;
    private int criticalMultiplierLevel=1;
    private int criticalMultiplierLevelStorage=0;
    private int stage=1;
    const int target_money=1000000000;
    const float BASE_CLICK_POWER_UPGRADE_COST=11;
    const float BASE_CLICK_POWER_UPGRADE_COST_INCREASE_MULTIPLIER=1.1f;
    private float currentTime;
    private float maxTime;

    public float Money{ get=>money;}
    public float TARGET_MONEY{get=>target_money;}
    public int ClickPower{ get=>clickPower;}
    public int ClickPowerLevel{get =>clickPowerLevel;}
    public float UpgradeClickPowerCost{ get=>BASE_CLICK_POWER_UPGRADE_COST/PriceDivider*Mathf.Pow(BASE_CLICK_POWER_UPGRADE_COST_INCREASE_MULTIPLIER,clickPowerLevel-1);}
    public float MoneyPerClick{ get=>PowerMultiplier*(1+ClickPowerMultiplier/100f);}
    public float ClickPowerMultiplier{ get=>PercentMultiplier*ClickPowerLevel;}
    public int PrestigePoints{ get=>prestigePoints;}
    public int ConvertCost{ get=>convertPrice;}

    public int PowerLevel{ get=>powerLevel;}
    public int PowerLevelStorage{ get=>powerLevelStorage;}
    public int PowerMultiplier{ get=>stage*powerLevel;}
    public int PowerMultiplierStorage{ get=>stage*powerLevelStorage;}
    public int PowerUpgradeCost{ get=>powerLevel+powerLevelStorage;}

    public int PercentLevel{ get=>percentLevel;}
    public int PercentLevelStorage{ get=>percentLevelStorage;}
    public int PercentMultiplier{ get=>stage*percentLevel;}
    public int PercentMultiplierStorage{ get=>stage*percentLevelStorage;}
    public int PercentUpgradeCost{ get=>percentLevel+percentLevelStorage;}

    public int PriceLevel{ get=>priceLevel;}
    public int PriceLevelStorage{ get=>priceLevelStorage;}
    public int PriceDivider{ get=>stage*priceLevel;}
    public int PriceDividerStorage{ get=>stage*priceLevelStorage;}
    public int PriceUpgradeCost{ get=>priceLevel+priceLevelStorage;}

    public int CriticalLevel{ get=>criticalLevel;}
    public int CriticalLevelStorage{ get=>criticalLevelStorage;}
    public int CriticalPercentage{ get=>stage*criticalLevel;}
    public int CriticalPercentageStorage{ get=>stage*criticalLevelStorage;}
    public int CriticalUpgradeCost{ get=>criticalLevel+criticalLevelStorage;}

    public int CriticalMultiplierLevel{ get=>criticalMultiplierLevel;}
    public int CriticalMultiplierLevelStorage{ get=>criticalMultiplierLevelStorage;}
    public int CriticalMultiplier{ get=>stage*criticalMultiplierLevel;}
    public int CriticalMultiplierStorage{ get=>stage*criticalMultiplierLevelStorage;}
    public int CriticalMultiplierUpgradeCost{ get=>criticalMultiplierLevel+CriticalMultiplierStorage;}

    public int Stage{ get=>stage;}
    public float CurrentTime{ get=>currentTime;}
    public float MaxTime{ get=>maxTime;}
    
    public void ChangeMoney(float amount){
        money+=amount;
    }

    public void ChangePrestigePoints(int amount){
        prestigePoints+=amount;
    }

    public void AddClickPowerLevel(){
        clickPowerLevel++;
    }

    public void AddConvertPrice(){
        convertPrice*=2;
    }

    public void AddPowerLevel(){
        powerLevelStorage++;
    }

    public void AddPercentLevel(){
        percentLevelStorage++;
    }

    public void AddPriceLevel(){
        priceLevelStorage++;
    }

    public void AddCriticalLevel(){
        criticalLevelStorage++;
    }

    public void AddCriticalMultiplierLevel(){
        criticalMultiplierLevelStorage++;
    }

    public void AddStage(){
        stage++;
    }

    public void Restart_1(){
        money=0;
        clickPowerLevel=1;
        prestigePoints=0;
        convertPrice=1000;

        for(int i=powerLevelStorage;i>0;i--){
            powerLevel++;
        }
        for(int i=percentLevelStorage;i>0;i--){
            percentLevel++;
        }
        for(int i=priceLevelStorage;i>0;i--){
            priceLevel++;
        }
        for(int i=criticalLevelStorage;i>0;i--){
            criticalLevel++;
        }
        for(int i=criticalMultiplierLevelStorage;i>0;i--){
            criticalMultiplierLevel++;
        }

        powerLevelStorage=0;
        percentLevelStorage=0;
        priceLevelStorage=0;
        criticalLevelStorage=0;
        criticalMultiplierLevelStorage=0;
    }

    public void Restart_2(){
        money=0;
        clickPowerLevel=1;
        prestigePoints=0;
        convertPrice=1000;

        powerLevel=1;
        percentLevel=1;
        priceLevel=1;
        criticalLevel=1;
        criticalMultiplierLevel=1;

        powerLevelStorage=0;
        percentLevelStorage=0;
        priceLevelStorage=0;
        criticalLevelStorage=0;
        criticalMultiplierLevelStorage=0;

        stage++;
    }
    
}
