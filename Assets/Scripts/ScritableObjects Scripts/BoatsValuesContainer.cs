using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "BoatsData", menuName = "ScriptableObject/boatsData")]
public class BoatsValuesContainer : ScriptableObject
{
    [Serializable]
    public struct Boats
    {
        public string name;
        public int id;
        public Sprite image;
        public int health;
        public float speed;
        public float strength;
    }

    [Serializable]
    public struct Store
    {
        public string name;
        public int id;
        public Sprite image;
        public float boatPrice;
        [TextAreaAttribute]
        public string description;
        public bool hasBougth;
        public bool boatSelected;
        //public bool ins;
    }
    [Serializable]
    public struct Upgrades
    {
        public string name;
        public int id;
        [Header("Prices of the upgrades")]
        public float healthPrice;
        public float speedPrice;
        public float moneyPrice;
        public float strengthPrice;
        [Header("Stages of the upgrades")]
        public int healtStage;
        public int speedStage;
        public int moneyStage;
        public int strengthStage;
        [Header("Totas stages of the upgrades")]
        public int healtTotalStages;
        public int speedTotalStages;
        public int moneyTotalStages;
        public int strengthTotalStages;
    }
    public Boats[] boatsDatas;
    public Store[] boatsStoreDatas;
    public Upgrades[] boatsUpgrades;


    public bool store;


    private void OnValidate()
    {
        if (boatsDatas.Length > 0)
        {
            for (int i = 0; i < boatsDatas.Length; i++)
            {
                boatsDatas[i].id = i;
            }

        }

        if (store)
        {
            boatsStoreDatas = new Store[boatsDatas.Length];
            boatsUpgrades = new Upgrades[boatsDatas.Length];

            for (int i = 0; i < boatsDatas.Length; i++)
            {
                boatsStoreDatas[i].name = boatsDatas[i].name;
                boatsStoreDatas[i].image = boatsDatas[i].image;
                boatsStoreDatas[i].id = i;

                boatsUpgrades[i].name = boatsDatas[i].name;
                boatsUpgrades[i].id = i;

            }

            store = false;
        }
    }

    public string GetName(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsDatas.FirstOrDefault(x => x.id == _id).name;
        else
            return boatsDatas.FirstOrDefault(x => x.name == _name).name;

    }

    public int GetId(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsDatas.FirstOrDefault(x => x.id == _id).id;
        else
            return boatsDatas.FirstOrDefault(x => x.name == _name).id;

    }

    public Sprite GetImage(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsDatas.FirstOrDefault(x => x.id == _id).image;
        else
            return boatsDatas.FirstOrDefault(x => x.name == _name).image;

    }

    public bool GetSelected(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsStoreDatas.FirstOrDefault(x => x.id == _id).boatSelected;
        else
            return boatsStoreDatas.FirstOrDefault(x => x.name == _name).boatSelected;

    }

    public bool GetBougth(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsStoreDatas.FirstOrDefault(x => x.id == _id).hasBougth;
        else
            return boatsStoreDatas.FirstOrDefault(x => x.name == _name).hasBougth;

    }

    public float GetPrice(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsStoreDatas.FirstOrDefault(x => x.id == _id).boatPrice;
        else
            return boatsStoreDatas.FirstOrDefault(x => x.name == _name).boatPrice;

    }

    public string GetDescription(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsStoreDatas.FirstOrDefault(x => x.id == _id).description;
        else
            return boatsStoreDatas.FirstOrDefault(x => x.name == _name).description;

    }

    public int GetHealth(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsDatas.FirstOrDefault(x => x.id == _id).health;
        else
            return boatsDatas.FirstOrDefault(x => x.name == _name).health;

    }

    public float GetSpeed(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsDatas.FirstOrDefault(x => x.id == _id).speed;
        else
            return boatsDatas.FirstOrDefault(x => x.name == _name).speed;

    }

    public float GetStrength(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsDatas.FirstOrDefault(x => x.id == _id).strength;
        else
            return boatsDatas.FirstOrDefault(x => x.name == _name).strength;

    }


    public void SetHasbougth(int _id, string _name, bool set)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsStoreDatas, x => x.id == _id);
            boatsStoreDatas[i].hasBougth = set;
        }
        else
        {
            int n = Array.FindIndex(boatsStoreDatas, x => x.name == _name);
            boatsStoreDatas[n].hasBougth = set;
        }

    }

    public void SetSelected(int _id, string _name, bool set)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsStoreDatas, x => x.id == _id);
            boatsStoreDatas[i].boatSelected = set;
        }
        else
        {
            int n = Array.FindIndex(boatsStoreDatas, x => x.name == _name);
            boatsStoreDatas[n].boatSelected = set;
        }

    }

    public void SetStength(int _id, string _name, int _strength)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsDatas, x => x.id == _id);
            boatsDatas[i].strength = _strength;
        }
        else
        {
            int n = Array.FindIndex(boatsDatas, x => x.name == _name);
            boatsDatas[n].strength = _strength;
        }

    }

    public void SetSpeed(int _id, string _name, int _speed)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsDatas, x => x.id == _id);
            boatsDatas[i].strength = _speed;
        }
        else
        {
            int n = Array.FindIndex(boatsDatas, x => x.name == _name);
            boatsDatas[n].strength = _speed;
        }

    }

    public void SetHealth(int _id, string _name, int _health)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsDatas, x => x.id == _id);
            boatsDatas[i].strength = _health;
        }
        else
        {
            int n = Array.FindIndex(boatsDatas, x => x.name == _name);
            boatsDatas[n].strength = _health;
        }

    }

    //upgrades price
    public float GetHealthUpgradePrice(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).healthPrice;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).healthPrice;

    }

    public void SetHealthUpgradePrice(int _id, string _name, float _value)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsUpgrades, x => x.id == _id);
            boatsUpgrades[i].healthPrice = _value;
        }
        else
        {
            int n = Array.FindIndex(boatsUpgrades, x => x.name == _name);
            boatsUpgrades[n].healthPrice = _value;
        }

    }

    public float GetSpeedUpgradePrice(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).speedPrice;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).speedPrice;

    }

    public void SetSpeedUpgradePrice(int _id, string _name, float _value)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsUpgrades, x => x.id == _id);
            boatsUpgrades[i].speedPrice = _value;
        }
        else
        {
            int n = Array.FindIndex(boatsUpgrades, x => x.name == _name);
            boatsUpgrades[n].speedPrice = _value;
        }

    }

    public float GetMoneyUpgradePrice(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).moneyPrice;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).moneyPrice;

    }

    public void SetMoneyUpgradePrice(int _id, string _name, float _value)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsUpgrades, x => x.id == _id);
            boatsUpgrades[i].moneyPrice = _value;
        }
        else
        {
            int n = Array.FindIndex(boatsUpgrades, x => x.name == _name);
            boatsUpgrades[n].moneyPrice = _value;
        }

    }

    public float GetStrengthUpgradePrice(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).strengthPrice;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).strengthPrice;

    }

    public void SetStrengthUpgradePrice(int _id, string _name, float _value)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsUpgrades, x => x.id == _id);
            boatsUpgrades[i].strengthPrice = _value;
        }
        else
        {
            int n = Array.FindIndex(boatsUpgrades, x => x.name == _name);
            boatsUpgrades[n].strengthPrice = _value;
        }

    }

    //end

    //upgrade stage

    public float GetHealthUpgradeStage(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).healtStage;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).healtStage;

    }

    public void SetHealthUpgradeStage(int _id, string _name, int _health)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsUpgrades, x => x.id == _id);
            boatsUpgrades[i].healtStage = _health;
        }
        else
        {
            int n = Array.FindIndex(boatsUpgrades, x => x.name == _name);
            boatsUpgrades[n].healtStage = _health;
        }

    }

    public float GetSpeedUpgradeStage(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).speedStage;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).speedStage;

    }

    public void SetSpeedUpgradeStage(int _id, string _name, int _health)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsUpgrades, x => x.id == _id);
            boatsUpgrades[i].speedStage = _health;
        }
        else
        {
            int n = Array.FindIndex(boatsUpgrades, x => x.name == _name);
            boatsUpgrades[n].speedStage = _health;
        }

    }

    public float GetMoneyUpgradeStage(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).moneyStage;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).moneyStage;

    }

    public void SetMoneyUpgradeStage(int _id, string _name, int _health)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsUpgrades, x => x.id == _id);
            boatsUpgrades[i].moneyStage = _health;
        }
        else
        {
            int n = Array.FindIndex(boatsUpgrades, x => x.name == _name);
            boatsUpgrades[n].moneyStage = _health;
        }

    }

    public float GetStrengthUpgradeStage(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).strengthStage;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).strengthStage;

    }

    public void SetStrengthUpgradeStage(int _id, string _name, int _health)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(boatsUpgrades, x => x.id == _id);
            boatsUpgrades[i].strengthStage = _health;
        }
        else
        {
            int n = Array.FindIndex(boatsUpgrades, x => x.name == _name);
            boatsUpgrades[n].strengthStage = _health;
        }

    }
    //end

    //upgrade total stage

    public float GetStrengthUpgradeTotalSatege(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).strengthTotalStages;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).strengthTotalStages;

    }

    public float GetHealthUpgradeTotalSatege(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).healtTotalStages;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).healtTotalStages;

    }

    public float GetMoneyUpgradeTotalSatege(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).moneyTotalStages;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).moneyTotalStages;

    }

    public float GetSpeedUpgradeTotalSatege(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsUpgrades.FirstOrDefault(x => x.id == _id).speedTotalStages;
        else
            return boatsUpgrades.FirstOrDefault(x => x.name == _name).speedTotalStages;

    }

}
