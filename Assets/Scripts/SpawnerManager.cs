using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
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
            yield return new WaitForSeconds(spawnCooldown);

            if (aerialEnable)
            {
                aerialSpawner.GetComponent<MobSpawner>().Spawn();
            }

            if (aquaticEnable)
            {
                aquaticSpawner.GetComponent<MobSpawner>().Spawn();
            }
        }
    }

    public void TurnOffSpawnsUntilClean()
    {
        aerialEnable = false;
        aquaticEnable = false;
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
        aerialEnable = true;
        aquaticEnable = true;
    }
}
