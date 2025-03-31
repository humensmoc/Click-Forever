using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject restart_1;
    public GameObject restart_2;
    public GameObject restart_3;

    public TMP_Text currentMoneyText;
    public TMP_Text clickPowerLevelText;
    public TMP_Text moneyPerClikeText;
    public TMP_Text clickPowerMultiplierText;
    public TMP_Text percentPerLevelText;
    public TMP_Text upgradeClickPowerCostText;
    public TMP_Text prestigePointsText;

    public TMP_Text convertPriceText;

    public TMP_Text powerLevelText;
    public TMP_Text powerMultiplierText;
    public TMP_Text upgradePowerCostText;

    public TMP_Text percentLevelText;
    public TMP_Text percentText;
    public TMP_Text upgradePercentCostText;

    public TMP_Text priceLevelText;
    public TMP_Text priceText;
    public TMP_Text upgradePriceCostText;

    public TMP_Text criticalMultiplierLevelText;
    public TMP_Text criticalMultiplierText;
    public TMP_Text upgradeCriticalMultiplierCostText;

    public TMP_Text criticalPercentageLevelText;
    public TMP_Text criticalPercentageText;
    public TMP_Text upgradeCriticalPercentageCostText;


    void Awake(){
        instance=this;
    }

    public void UpdateUI(){
        currentMoneyText.text=Model.instance.Money.ToString();

        if(Model.instance.Money>=Model.instance.TARGET_MONEY)
        {
            restart_2.SetActive(true);
        }

        clickPowerLevelText.text="LV"+Model.instance.ClickPowerLevel.ToString();
        moneyPerClikeText.text="Money per click: "+Model.instance.MoneyPerClick.ToString();
        clickPowerMultiplierText.text=Model.instance.ClickPowerMultiplier.ToString()+"%";
        percentPerLevelText.text="+"+Model.instance.PercentMultiplier.ToString()+"%";
        upgradeClickPowerCostText.text=Model.instance.UpgradeClickPowerCost.ToString();
        prestigePointsText.text=Model.instance.PrestigePoints.ToString();

        convertPriceText.text=Model.instance.ConvertCost.ToString();

        if(Model.instance.PercentLevelStorage>0){
            percentLevelText.text="LV"+Model.instance.PercentLevel.ToString()+"+"+Model.instance.PercentLevelStorage.ToString();
            percentText.text=Model.instance.PercentMultiplier.ToString()+"+"+Model.instance.PercentMultiplierStorage.ToString()+"%";
            upgradePercentCostText.text=Model.instance.PercentUpgradeCost.ToString();
        }
        else{
            percentLevelText.text="LV"+Model.instance.PercentLevel.ToString();
            percentText.text=Model.instance.PercentMultiplier.ToString()+"%";
            upgradePercentCostText.text=Model.instance.PercentUpgradeCost.ToString();
        }

        if(Model.instance.PowerLevelStorage>0){
            powerLevelText.text="LV"+Model.instance.PowerLevel.ToString()+"+"+Model.instance.PowerLevelStorage.ToString();
            powerMultiplierText.text="x"+Model.instance.PowerMultiplier.ToString()+"+"+Model.instance.PowerMultiplierStorage.ToString();
            upgradePowerCostText.text=Model.instance.PowerUpgradeCost.ToString();
        }
        else{
            powerLevelText.text="LV"+Model.instance.PowerLevel.ToString();
            powerMultiplierText.text="x"+Model.instance.PowerMultiplier.ToString();
            upgradePowerCostText.text=Model.instance.PowerUpgradeCost.ToString();
        }

        if(Model.instance.PriceLevelStorage>0){
            priceLevelText.text="LV"+Model.instance.PriceLevel.ToString()+"+"+Model.instance.PriceLevelStorage.ToString();
            priceText.text="/"+Model.instance.PriceDivider.ToString()+"+"+Model.instance.PriceDividerStorage.ToString();
            upgradePriceCostText.text=Model.instance.PriceUpgradeCost.ToString();
        }
        else{
            priceLevelText.text="LV"+Model.instance.PriceLevel.ToString();
            priceText.text="/"+Model.instance.PriceDivider.ToString();
            upgradePriceCostText.text=Model.instance.PriceUpgradeCost.ToString();
        }

        if(Model.instance.CriticalMultiplierLevelStorage>0){
            criticalMultiplierLevelText.text="LV"+Model.instance.CriticalMultiplierLevel.ToString()+"+"+Model.instance.CriticalMultiplierLevelStorage.ToString();
            criticalMultiplierText.text="x"+Model.instance.CriticalMultiplier.ToString()+"+"+Model.instance.CriticalMultiplierStorage.ToString();
            upgradeCriticalMultiplierCostText.text=Model.instance.CriticalMultiplierUpgradeCost.ToString();
        }
        else{
            criticalMultiplierLevelText.text="LV"+Model.instance.CriticalMultiplierLevel.ToString();
            criticalMultiplierText.text="x"+Model.instance.CriticalMultiplier.ToString();
            upgradeCriticalMultiplierCostText.text=Model.instance.CriticalMultiplierUpgradeCost.ToString();
        }

        if(Model.instance.CriticalLevelStorage>0){
            criticalPercentageLevelText.text="LV"+Model.instance.CriticalLevel.ToString()+"+"+Model.instance.CriticalLevelStorage.ToString();
            criticalPercentageText.text=Model.instance.CriticalPercentage.ToString()+"+"+Model.instance.CriticalPercentageStorage.ToString()+"%";
            upgradeCriticalPercentageCostText.text=Model.instance.CriticalUpgradeCost.ToString();
        }
        else{
            criticalPercentageLevelText.text="LV"+Model.instance.CriticalLevel.ToString();
            criticalPercentageText.text=Model.instance.CriticalPercentage.ToString()+"%";
            upgradeCriticalPercentageCostText.text=Model.instance.CriticalUpgradeCost.ToString();
        }
    }

    //for test
    public void AddMoney(){
        Model.instance.ChangeMoney(10000);
        UpdateUI();
    }

    public void UpgradeClickPower(){
        if(Model.instance.Money>=Model.instance.UpgradeClickPowerCost){
            Model.instance.ChangeMoney(-Model.instance.UpgradeClickPowerCost);
            Model.instance.AddClickPowerLevel();
        }
        UpdateUI();
    }

    public void UpgradeClickPowerToMax(){
        while(Model.instance.Money>=Model.instance.UpgradeClickPowerCost){
            UpgradeClickPower();
        }
        UpdateUI();
    }

    public void Convert(){
        if(Model.instance.Money>=Model.instance.ConvertCost){
            Model.instance.ChangeMoney(-(int)Model.instance.ConvertCost);
            Model.instance.AddConvertPrice();
            Model.instance.ChangePrestigePoints(1);
        }
        UpdateUI();
    }

    public void UpgradePercent(){
        if(Model.instance.PrestigePoints>=Model.instance.PercentLevel){
            Model.instance.ChangePrestigePoints(-Model.instance.PercentLevel);
            Model.instance.AddPercentLevel();
        }

        if(!restart_1.activeSelf){
            restart_1.SetActive(true);
        }
        UpdateUI();
    }

    public void UpgradePrice(){
        if(Model.instance.PrestigePoints>=Model.instance.PriceLevel){
            Model.instance.ChangePrestigePoints(-Model.instance.PriceLevel);
            Model.instance.AddPriceLevel();
        }

        if(!restart_1.activeSelf){
            restart_1.SetActive(true);
        }
        UpdateUI();
    }

    public void UpgradePower(){     
        if(Model.instance.PrestigePoints>=Model.instance.PowerLevel){
            Model.instance.ChangePrestigePoints(-Model.instance.PowerLevel);
            Model.instance.AddPowerLevel();
        }

        if(!restart_1.activeSelf){
            restart_1.SetActive(true);
        }
        UpdateUI();
    }

    public void UpgradeCriticalMultiplier(){
        if(Model.instance.PrestigePoints>=Model.instance.CriticalMultiplierLevel){
            Model.instance.ChangePrestigePoints(-Model.instance.CriticalMultiplierLevel);
            Model.instance.AddCriticalMultiplierLevel();
        }

        if(!restart_1.activeSelf){
            restart_1.SetActive(true);
        }
        UpdateUI();
    }

    public void UpgradeCriticalPercentage(){
        if(Model.instance.PrestigePoints>=Model.instance.CriticalLevel){
            Model.instance.ChangePrestigePoints(-Model.instance.CriticalLevel);
            Model.instance.AddCriticalLevel();
        }

        if(!restart_1.activeSelf){
            restart_1.SetActive(true);
        }
        UpdateUI();
    }

    public void Restart_1(){
        Model.instance.Restart_1();
        restart_1.SetActive(false);
        Debug.Log("Restart_1");
        UpdateUI();
    }

    public void Restart_2(){
        Model.instance.Restart_2();
        restart_1.SetActive(false);
        Debug.Log("Restart_2");
        UpdateUI();
    }

    public void Restart_3(){
        Debug.Log("Restart_3");
        UpdateUI();
    }
    
}
