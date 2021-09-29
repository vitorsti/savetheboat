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
    public struct Upgrades { public TextMeshProUGUI upgradeName; public Slider upgradeStage; public Button buyBuytton; }
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

    public void Close()
    {

        Destroy(this.gameObject);
    }
}
