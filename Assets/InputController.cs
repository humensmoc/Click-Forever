using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    public Button addMoneyBtn;

    public Button restart_1;
    public Button restart_2;
    public Button restart_3;
    public Button upgradeClickPowerBtn;
    public Button upgradeClickPowerToMaxBtn;
    public Button upgradePercentBtn;
    public Button upgradePriceBtn;
    public Button upgradePowerBtn;
    public Button upgradeCriticalMultiplierBtn;
    public Button upgradeCriticalPercentageBtn;
    public Button convertBtn;
    

    void Awake(){
        instance=this;
    }

    void Start()
    {
        UIController.instance.UpdateUI();

        restart_1.onClick.AddListener(UIController.instance.Restart_1);
        restart_2.onClick.AddListener(UIController.instance.Restart_2);
        restart_3.onClick.AddListener(UIController.instance.Restart_3);

        upgradeClickPowerBtn.onClick.AddListener(UIController.instance.UpgradeClickPower);
        upgradeClickPowerToMaxBtn.onClick.AddListener(UIController.instance.UpgradeClickPowerToMax);

        upgradePercentBtn.onClick.AddListener(UIController.instance.UpgradePercent);
        upgradePriceBtn.onClick.AddListener(UIController.instance.UpgradePrice);
        upgradePowerBtn.onClick.AddListener(UIController.instance.UpgradePower);
        upgradeCriticalMultiplierBtn.onClick.AddListener(UIController.instance.UpgradeCriticalMultiplier);
        upgradeCriticalPercentageBtn.onClick.AddListener(UIController.instance.UpgradeCriticalPercentage);
        convertBtn.onClick.AddListener(UIController.instance.Convert);

        addMoneyBtn.onClick.AddListener(UIController.instance.AddMoney);
    }
}
