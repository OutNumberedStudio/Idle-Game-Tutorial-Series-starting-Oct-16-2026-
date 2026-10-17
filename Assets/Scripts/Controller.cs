using UnityEngine;
using TMPro;
using BreakInfinity;
using System;

public class Controller : MonoBehaviour
{
    public UpgradesManager upgradesManager;
    public Data data;

    public TMP_Text flaskstext;

    [SerializeField] private TMP_Text flasksText;
    [SerializeField] private TMP_Text flasksClickPowerText;

    public BigDouble ClickPower()
    {
        return 1 + data.clickUpgadeLevel;
    }


    //Start() goes on starting the game
    private void Start()
    {
        data = new Data();
        upgradesManager.StartUpgradeManager();
    }

    /// Displays the amount of flasks every fram
    private void Update()
    {
        flaskstext.text = data.flasks + " Flasks";
        flasksClickPowerText.text = "+" + ClickPower() + "Flasks";
    }

    public void GeneratesFlasks()
    {
        //uses Data script to access variable flasks and then adds 1
        //data.flasks += 1;
        data.flasks += ClickPower();
    }
}
