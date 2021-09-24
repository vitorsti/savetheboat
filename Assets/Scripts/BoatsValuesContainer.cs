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
        [TextAreaAttribute]
        public string effectDescription;
        public bool hasBougth;
        public bool boatSelected;
        //public bool ins;
    }
    public Boats[] boatsDatas;
    public Store[] boatsStoreDatas;

    public bool store;


    private void OnValidate()
    {
        for (int i = 0; i < boatsDatas.Length; i++)
        {
            boatsDatas[i].id = i;
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

    public Sprite GetImage(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return boatsDatas.FirstOrDefault(x => x.id == _id).image;
        else
            return boatsDatas.FirstOrDefault(x => x.name == _name).image;

    }

    public bool GetSelected(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " " )
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

    /*public void SetIns(string _name)
    {
        int i = Array.FindIndex(boatsStoreDatas, x=> x.name == _name);
        boatsStoreDatas[i].ins = true;
    }
*/

}
