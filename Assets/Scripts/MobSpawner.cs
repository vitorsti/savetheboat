using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public float areaMinX;
    public float areaMaxX;

    public float areaMinY;
    public float areaMaxY;

    public List<GameObject> possibleMobs;

    public void Spawn(int qtd = 1)
    {
        for (int i = 0; i < qtd; i++)
        {
            Vector2 pos = new Vector2(UnityEngine.Random.Range(areaMinX, areaMaxX), UnityEngine.Random.Range(areaMinY, areaMaxY));
            int index = UnityEngine.Random.Range(0, possibleMobs.Count);
            GameObject go = Instantiate(possibleMobs[index], pos, Quaternion.identity);
            go.name = possibleMobs[index].name;

            //Event
        }
    }
}
