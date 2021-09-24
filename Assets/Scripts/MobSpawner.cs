using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [Header("Spawn Area")]
    public float areaMinX;
    public float areaMaxX;
    public float areaMinY;
    public float areaMaxY;

    [Header("Multipliers")]
    public int lifeMultiplier = 1;
    public float speedMultiplier = 1;
    public float strengthMultiplier = 1;

    [Header("Lists")]
    public bool usingCustomList;
    public List<GameObject> possibleMobs;
    public List<GameObject> customMobs;

    public void Spawn(int qtd = 1)
    {
        for (int i = 0; i < qtd; i++)
        {
            Vector2 pos = new Vector2(UnityEngine.Random.Range(areaMinX, areaMaxX), UnityEngine.Random.Range(areaMinY, areaMaxY));
            int index;
            GameObject go;

            if (!usingCustomList)
            {
                index = UnityEngine.Random.Range(0, possibleMobs.Count);
                go = Instantiate(possibleMobs[index], pos, Quaternion.identity);
                go.name = possibleMobs[index].name;
            }
            else
            {
                index = UnityEngine.Random.Range(0, customMobs.Count);
                go = Instantiate(customMobs[index], pos, Quaternion.identity);
                go.name = customMobs[index].name;
            }

            if (lifeMultiplier != 1)
                go.GetComponent<Monster>().life *= lifeMultiplier;
            if (speedMultiplier != 1)
                go.GetComponent<Monster>().speed *= speedMultiplier;
        }
    }

    public void ChangeLifeMultiplier(int value)
    {
        lifeMultiplier = value;
    }

    public void ChangeSpeedMultiplier(float value)
    {
        speedMultiplier = value;
    }

    public void ChangeStrenghtMultiplier(float value)
    {
        strengthMultiplier = value;
    }


    public void TurnCustomList(bool turn)
    {
        usingCustomList = turn;
    }

    public void SetListOfMobs(List<GameObject> mobsList)
    {
        possibleMobs = new List<GameObject>();
        possibleMobs = mobsList;
    }
    public void SetCustomList(List<GameObject> customList)
    {
        customMobs = new List<GameObject>();
        customMobs.AddRange(customList);
    }

}
