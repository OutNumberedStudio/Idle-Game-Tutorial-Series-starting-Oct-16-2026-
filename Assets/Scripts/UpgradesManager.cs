using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public Controller controller;
    public Data data;

    public Upgrades clickUpgrade;

    public string clickUpgradeName;





    public BigDouble clickUpgradeBaseCost;
    public BigDouble clickUpgradeCostMult;

    public void StartUpgradeManager()
    {
        data = controller.data;
        clickUpgradeBaseCost = 10;
        clickUpgradeCostMult = 1.5;
        UpdateClickUpgradeUI();
    }

    public void UpdateClickUpgradeUI()
    {
        clickUpgrade.LevelText.text = controller.data.clickUpgadeLevel.ToString();
        clickUpgrade.CostText.text = "Cost: " + Cost().ToString(format: "F2") + " Flasks";
        clickUpgrade.NameText.text = "+1 " + clickUpgradeName;
    }

    public BigDouble Cost()
    {
        return clickUpgradeBaseCost * BigDouble.Pow(clickUpgradeCostMult, controller.data.clickUpgadeLevel);
    }

    public void BuyUpgrade()
    {
        if (controller.data.flasks >= Cost())
        {
            controller.data.flasks -= Cost();
            controller.data.clickUpgadeLevel += 1;
        }
        UpdateClickUpgradeUI();
    }

}
