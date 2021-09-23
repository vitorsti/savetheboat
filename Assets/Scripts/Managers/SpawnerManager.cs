using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float spawnCycleCooldown;
    public float spawnCooldown;

    public GameObject aerialSpawner;
    public GameObject aquaticSpawner;

    public bool aerialEnable = true;
    public bool aquaticEnable = true;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    public IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnCycleCooldown);
            Random.InitState((int)System.DateTime.Now.Ticks);
            int spawnQtd = SpawnQuantity();

            if(aerialEnable && aquaticEnable)
            {
                int aerialQtd = Random.Range(1, spawnQtd);
                int aquaticQtd = spawnQtd - aerialQtd;

                while (aerialQtd != 0 && aquaticQtd != 0)
                {
                    if(aerialQtd != 0)
                    {
                        int willSpawn = Random.Range(0, aerialQtd + 1);
                        aerialQtd -= willSpawn;
                        aerialSpawner.GetComponent<MobSpawner>().Spawn(willSpawn);
                    }

                    if (aquaticQtd != 0)
                    {
                        int willSpawn = Random.Range(0, aquaticQtd + 1);
                        aquaticQtd -= willSpawn;
                        aquaticSpawner.GetComponent<MobSpawner>().Spawn(willSpawn);
                    }

                    yield return new WaitForSeconds(spawnCooldown);
                }
            }

            else if (aerialEnable)
            {
                while (spawnQtd != 0)
                {
                    int willSpawn = Random.Range(0, spawnQtd + 1);
                    spawnQtd -= willSpawn;
                    aerialSpawner.GetComponent<MobSpawner>().Spawn(willSpawn);
                    yield return new WaitForSeconds(spawnCooldown);
                }
            }

            else if (aquaticEnable)
            {
                while (spawnQtd != 0)
                {
                    int willSpawn = Random.Range(0, spawnQtd + 1);
                    spawnQtd -= willSpawn;
                    aquaticSpawner.GetComponent<MobSpawner>().Spawn(willSpawn);
                    yield return new WaitForSeconds(spawnCooldown);
                }
            }
        }
    }

    public int SpawnQuantity()
    {
        int maxPossible = 4;

        if (aerialEnable && aquaticEnable)
            return Random.Range(0, maxPossible);
        else
            return Random.Range(0, (maxPossible/2)+1);

        //TO DO 
        // return Random.Range(0, 3);
    }

    public void StopSpawner()
    {
        StopCoroutine(SpawnRoutine());
    }

    public void TurnOffSpawnsUntilClean()
    {
        //aerialEnable = false;
        //aquaticEnable = false;

        StopCoroutine(SpawnRoutine());
        StartCoroutine(TurnOffSpawnsUntilCleanRoutine());
    }

    IEnumerator TurnOffSpawnsUntilCleanRoutine()
    {
        bool monsterOnScreen = true;
        while (monsterOnScreen)
        {
            yield return new WaitForSeconds(3f);
            int mobs = GameObject.FindGameObjectsWithTag("Mobs").Length;
            if (mobs <= 0)
                monsterOnScreen = false;
        }
        StartCoroutine(SpawnRoutine());
        //aerialEnable = true;
        //aquaticEnable = true;
    }
}
