using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "EnemiesContainerValues", menuName = "ScriptableObject/enemiesData")]
public class EnemiesValuesContainer : ScriptableObject
{
    public enum EnemieType { fly, sea }
    [Serializable]
    public struct EnemiesData
    {
        public string name;
        public int id;
        public float strength;
        public float life;
        public float speed;
        public EnemieType type;
        public Sprite image;
        public bool hasFound;
        [TextArea]
        public string description;

    }

    public EnemiesData[] datas;

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

    public Sprite GetImage(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).image;
        else
            return datas.FirstOrDefault(x => x.name == _name).image;

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

    public string GetDescription(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).description;
        else
            return datas.FirstOrDefault(x => x.name == _name).description;

    }

    public float GetHealth(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).life;
        else
            return datas.FirstOrDefault(x => x.name == _name).life;

    }

    public float GetStrength(int _id, string _name)
    {

        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).strength;
        else
            return datas.FirstOrDefault(x => x.name == _name).strength;

    }

    public EnemieType GetType(int _id, string _name)
    {
        if (_name == null || _name == "" || _name == " ")
            return datas.FirstOrDefault(x => x.id == _id).type;
        else
            return datas.FirstOrDefault(x => x.name == _name).type;

    }



}
