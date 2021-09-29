using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


[CreateAssetMenu(fileName = "PowerupValuesContainer", menuName = "ScriptableObject/powerupsData")]
public class PowerupValuesContainer : ScriptableObject
{
    [Serializable]
    public struct PowerupsData
    {
        public string name;
        public int id;
        public float duration;
        [TextArea]
        public string description;
        public bool hasFound;
        public Sprite image;
    }

    public PowerupsData[] datas;

    private void OnValidate()
    {
        if (datas.Length > 0)
        {
            for (int i = 0; i < datas.Length; i++)
            {
                datas[i].id = i;
            }
        }
    }

    public string GetName(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).name;
        else
            return datas.FirstOrDefault(x => x.name == _name).name;

    }

    public int GetId(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).id;
        else
            return datas.FirstOrDefault(x => x.name == _name).id;

    }

    public string GetDescription(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).description;
        else
            return datas.FirstOrDefault(x => x.name == _name).description;

    }

    public bool GetHasfound(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).hasFound;
        else
            return datas.FirstOrDefault(x => x.name == _name).hasFound;

    }

    public void SetHasfound(int _id, string _name)
    {
        if (_name == null || _name == "" || _name == " ")
        {
            int i = Array.FindIndex(datas, x => x.id == _id);
            datas[i].hasFound = true;
        }
        else
        {
            int n = Array.FindIndex(datas, x => x.name == _name);
            datas[n].hasFound = true;
        }

    }

    public Sprite GetImage(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).image;
        else
            return datas.FirstOrDefault(x => x.name == _name).image;

    }

    public float GetDuration(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).duration;
        else
            return datas.FirstOrDefault(x => x.name == _name).duration;

    }
}

