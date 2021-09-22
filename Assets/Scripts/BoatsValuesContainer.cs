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
        public float price;
        public int upgradelvl;
        public float boatPrice;
        [TextAreaAttribute]
        public string description;
        [TextAreaAttribute]
        public string effectDescription;

        [SerializeField]
        private bool hasBougth { get; set; }
        [SerializeField]
        private bool boatSelected { get; set; }
    }
    public Boats[] boatsDatas;
    public Store[] boatsStoreDatas;

    private void OnValidate()
    {
        for (int i = 0; i < boatsDatas.Length; i++)
        {
            boatsDatas[i].id = i;
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

    
}
