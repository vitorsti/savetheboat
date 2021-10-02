using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BoatInfoWindowManager : MonoBehaviour
{
    BoatsValuesContainer data;
    public Button closeBttun;
    public Image boatImage;
    public TextMeshProUGUI descriptiontxt;
    [Serializable]
    public struct Upgrades { public string name; public TextMeshProUGUI upgradeName; public Slider upgradeStage; public Button buyBuytton; public float priceMultiplier; public float upPrice; }
    public Upgrades[] upgrades;
    public Button buySelectBttun;
    public string boatName;
    private void Awake()
    {
        data = Resources.Load<BoatsValuesContainer>("ScriptableObjects/BoatsData");
        closeBttun.onClick.AddListener(Close);
        Debug.Log(boatName);
    }

    private void Start()
    {
        SetThings();
    }

    public void SetThings()
    {
        boatImage.sprite = data.GetImage(0, boatName);
        descriptiontxt.text = data.GetDescription(0, boatName);

        SetUpgradeTab();


        bool hasbougth = data.GetBougth(0, boatName);
        bool selected = data.GetSelected(0, boatName);

        if (!hasbougth)
        {
            SetBuyBoatButton();
        }

        if (hasbougth && !selected)
        {
            SetChooseBoatButton();
        }

        if (selected)
        {
            SetBoatSelectedButton();
        }

    }

    public void SetUpgradeTab()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            upgrades[i].buyBuytton.onClick.RemoveAllListeners();
        }
        //uipgrade order 0-health 1-speed 2-strength 3-money
        upgrades[0].upPrice = data.GetHealthUpgradePrice(0, boatName);
        upgrades[1].upPrice = data.GetSpeedUpgradePrice(0, boatName);
        upgrades[2].upPrice = data.GetStrengthUpgradePrice(0, boatName);
        upgrades[3].upPrice = data.GetMoneyUpgradePrice(0, boatName);

        if (data.GetHealthUpgradeStage(0, boatName) != data.GetHealthUpgradeTotalSatege(0, boatName))
            upgrades[0].buyBuytton.GetComponentInChildren<TextMeshProUGUI>().text = upgrades[0].upPrice.ToString();
        else
            upgrades[0].buyBuytton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";

        if (data.GetSpeedUpgradeStage(0, boatName) != data.GetSpeedUpgradeTotalSatege(0, boatName))
            upgrades[1].buyBuytton.GetComponentInChildren<TextMeshProUGUI>().text = upgrades[1].upPrice.ToString();
        else
            upgrades[1].buyBuytton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";

        if (data.GetStrengthUpgradeStage(0, boatName) != data.GetStrengthUpgradeTotalSatege(0, boatName))
            upgrades[2].buyBuytton.GetComponentInChildren<TextMeshProUGUI>().text = upgrades[2].upPrice.ToString();
        else
            upgrades[2].buyBuytton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";

        if (data.GetMoneyUpgradeStage(0, boatName) != data.GetMoneyUpgradeTotalSatege(0, boatName))
            upgrades[3].buyBuytton.GetComponentInChildren<TextMeshProUGUI>().text = upgrades[3].upPrice.ToString();
        else
            upgrades[3].buyBuytton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";

        upgrades[0].upgradeStage.maxValue = data.GetHealthUpgradeTotalSatege(0, boatName);
        upgrades[1].upgradeStage.maxValue = data.GetSpeedUpgradeTotalSatege(0, boatName);
        upgrades[2].upgradeStage.maxValue = data.GetStrengthUpgradeTotalSatege(0, boatName);
        upgrades[3].upgradeStage.maxValue = data.GetMoneyUpgradeTotalSatege(0, boatName);

        upgrades[0].upgradeStage.value = data.GetHealthUpgradeStage(0, boatName);
        upgrades[1].upgradeStage.value = data.GetSpeedUpgradeStage(0, boatName);
        upgrades[2].upgradeStage.value = data.GetStrengthUpgradeStage(0, boatName);
        upgrades[3].upgradeStage.value = data.GetMoneyUpgradeStage(0, boatName);

        for (int i = 0; i < upgrades.Length; i++)
        {
            upgrades[i].upgradeName.text = upgrades[i].name + ": lvl " + upgrades[i].upgradeStage.value.ToString();
            int index = i;
            if (data.GetBougth(0, boatName))
            {
                upgrades[i].buyBuytton.interactable = true;
                upgrades[i].buyBuytton.onClick.AddListener(delegate { BuyUpgrade(index); });
            }
            else
            {
                upgrades[i].buyBuytton.interactable = false;
                upgrades[i].buyBuytton.GetComponentInChildren<TextMeshProUGUI>().text = "unavailable";
            }
        }
    }

    public void SetBuyBoatButton()
    {
        buySelectBttun.onClick.RemoveAllListeners();
        buySelectBttun.onClick.AddListener(Buy);
        buySelectBttun.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + data.GetPrice(0, boatName);
    }

    public void SetChooseBoatButton()
    {
        buySelectBttun.onClick.RemoveAllListeners();
        buySelectBttun.onClick.AddListener(Select);
        buySelectBttun.GetComponentInChildren<TextMeshProUGUI>().text = "Use Boat";
    }

    public void SetBoatSelectedButton()
    {
        buySelectBttun.onClick.RemoveAllListeners();
        buySelectBttun.GetComponentInChildren<TextMeshProUGUI>().text = "Boat Selected";
        buySelectBttun.interactable = false;

    }

    public void Buy()
    {
        data.SetHasbougth(0, boatName, true);
        Debug.Log("boat bougth");
        SetChooseBoatButton();
        SetUpgradeTab();
    }

    public void Select()
    {
        for (int i = 0; i < data.boatsDatas.Length; i++)
        {
            if (data.GetSelected(i, null))
                data.SetSelected(i, null, false);
        }

        data.SetSelected(0, boatName, true);
        Debug.Log("boat selected");
        SetBoatSelectedButton();
        BoatsContentPageManager pageManager = FindObjectOfType<BoatsContentPageManager>();
        pageManager.Spawn(pageManager.page);
    }

    public void BuyUpgrade(int index)
    {
        if (upgrades[index].upgradeStage.value == upgrades[index].upgradeStage.maxValue)
            return;
        float multi = upgrades[index].priceMultiplier;
        float newPrice = 0;
        upgrades[index].upgradeStage.value++;
        switch (index)
        {
            case 0:
                newPrice = data.GetHealthUpgradePrice(0, boatName) * multi;
                data.SetHealthUpgradePrice(0, boatName, (int)newPrice);
                data.SetHealthUpgradeStage(0, boatName, (int)upgrades[index].upgradeStage.value);
                Debug.Log(index);
                break;
            case 1:
                newPrice = data.GetSpeedUpgradePrice(0, boatName) * multi;
                data.SetSpeedUpgradePrice(0, boatName, (int)newPrice);
                data.SetSpeedUpgradeStage(0, boatName, (int)upgrades[index].upgradeStage.value);
                Debug.Log(index);
                Debug.Log(index);
                break;
            case 2:
                newPrice = data.GetStrengthUpgradePrice(0, boatName) * multi;
                data.SetStrengthUpgradePrice(0, boatName, (int)newPrice);
                data.SetStrengthUpgradeStage(0, boatName, (int)upgrades[index].upgradeStage.value);
                Debug.Log(index);
                Debug.Log(index);
                break;
            case 3:
                newPrice = data.GetMoneyUpgradePrice(0, boatName) * multi;
                data.SetMoneyUpgradePrice(0, boatName, (int)newPrice);
                data.SetMoneyUpgradeStage(0, boatName, (int)upgrades[index].upgradeStage.value);
                Debug.Log(index);
                Debug.Log(index);
                break;
        }

        SetUpgradeTab();
    }

    public void Close()
    {

        Destroy(this.gameObject);
    }
}
