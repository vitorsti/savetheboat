using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardDiaryContentManager : MonoBehaviour
{
    public BossValuesContainer bossValues;
    public EnemiesValuesContainer enemiesValues;
    public PowerupValuesContainer powerupValues;
    public EventsValuesContainer eventsValues;
    public enum Itens { enemies, boss, powerup, events }
    public Itens itens;
    public List<int> sort;
    public List<GameObject> prefabs;
    public GameObject prefab;
    void Awake()
    {
        bossValues = Resources.Load<BossValuesContainer>("ScriptableObjects/BossData");
        enemiesValues = Resources.Load<EnemiesValuesContainer>("ScriptableObjects/EnemiesData");
        powerupValues = Resources.Load<PowerupValuesContainer>("ScriptableObjects/PowerupsData");
        eventsValues = Resources.Load<EventsValuesContainer>("ScriptableObjects/EventsData");
    }

    void Start()
    {
        Sort(0);
    }

    public void Sort(int value)
    {
        if (sort.Count > 0)
            sort.Clear();
        switch ((Itens)value)
        {

            case Itens.enemies:
                {
                    for (int i = 0; i < enemiesValues.datas.Length; i++)
                    {
                        if (enemiesValues.GetHasfound(i, null))
                            sort.Add(enemiesValues.datas[i].id);

                    }

                    for (int i = 0; i < enemiesValues.datas.Length; i++)
                    {
                        if (!enemiesValues.GetHasfound(i, null))
                            sort.Add(enemiesValues.datas[i].id);
                    }

                    break;
                }
            case Itens.boss:
                {
                    for (int i = 0; i < bossValues.datas.Length; i++)
                    {
                        if (bossValues.GetHasfound(i, null))
                            sort.Add(bossValues.datas[i].id);

                    }

                    for (int i = 0; i < bossValues.datas.Length; i++)
                    {
                        if (!bossValues.GetHasfound(i, null))
                            sort.Add(bossValues.datas[i].id);
                    }
                    break;
                }
            case Itens.powerup:
                {
                    for (int i = 0; i < powerupValues.datas.Length; i++)
                    {
                        if (powerupValues.GetHasfound(i, null))
                            sort.Add(powerupValues.datas[i].id);

                    }

                    for (int i = 0; i < powerupValues.datas.Length; i++)
                    {
                        if (!powerupValues.GetHasfound(i, null))
                            sort.Add(powerupValues.datas[i].id);
                    }
                    break;
                }
            case Itens.events:
                {
                    for (int i = 0; i < eventsValues.datas.Length; i++)
                    {
                        if (eventsValues.GetHasfound(i, null))
                            sort.Add(eventsValues.datas[i].id);

                    }

                    for (int i = 0; i < eventsValues.datas.Length; i++)
                    {
                        if (!eventsValues.GetHasfound(i, null))
                            sort.Add(eventsValues.datas[i].id);
                    }
                    break;
                }

        }

        Spawn(value);
    }

    public void Spawn(int value)
    {
        if (prefabs.Count > 0)
        {
            foreach (GameObject i in prefabs)
            {
                Destroy(i);
            }
            prefabs.Clear();
        }
        int temp = value;
        switch ((Itens)value)
        {


            case Itens.enemies:
                {
                    Debug.Log(value);
                    for (int i = 0; i < sort.Count; i++)
                    {
                        GameObject go = Instantiate(prefab, this.transform.position, this.transform.rotation, this.transform);
                        go.name = enemiesValues.GetName(sort[i], null);
                        go.SendMessage("SetType", temp);
                        prefabs.Add(go);
                    }

                    break;
                }
            case Itens.boss:
                {
                    Debug.Log(value);
                    for (int i = 0; i < sort.Count; i++)
                    {
                        GameObject go = Instantiate(prefab, this.transform.position, this.transform.rotation, this.transform);
                        go.name = bossValues.GetName(sort[i], null);
                        go.SendMessage("SetType", temp);
                        prefabs.Add(go);
                    }

                    break;
                }
            case Itens.powerup:
                {
                    Debug.Log(value);
                    for (int i = 0; i < sort.Count; i++)
                    {
                        GameObject go = Instantiate(prefab, this.transform.position, this.transform.rotation, this.transform);
                        go.name = powerupValues.GetName(sort[i], null);
                        go.SendMessage("SetType", temp);
                        prefabs.Add(go);
                    }

                    break;
                }
            case Itens.events:
                {
                    Debug.Log(value);
                    for (int i = 0; i < sort.Count; i++)
                    {
                        GameObject go = Instantiate(prefab, this.transform.position, this.transform.rotation, this.transform);
                        go.name = eventsValues.GetName(sort[i], null);
                        go.SendMessage("SetType", temp);
                        prefabs.Add(go);
                    }

                    break;
                }

        }
    }
}
