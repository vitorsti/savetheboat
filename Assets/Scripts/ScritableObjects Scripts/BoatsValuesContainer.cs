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
    public Boats[] boatsDatas;
    public Store[] boatsStoreDatas;

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

            for (int i = 0; i < boatsDatas.Length; i++)
            {
                boatsStoreDatas[i].name = boatsDatas[i].name;
                boatsStoreDatas[i].image = boatsDatas[i].image;
                boatsStoreDatas[i].id = i;
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

}
