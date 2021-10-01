using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameLibrary;

public class PowerUpManager : MonoBehaviour
{
    public int minSpawnCooldown;
    public int maxSpawnCooldown;

    [SerializeField] int spawnCooldown;

    [SerializeField] float ySpawn;
    [SerializeField] float xSpawn;

    public bool powerUpOn;
    public bool powerUpSpawned;

    public PowerUp activePowerUp;

    public List<PowerUpLibrary> possiblePowerUps;

    public List<PowerUp> powerUpList;

    public static PowerUpManager Singleton { get; private set; }

    [Serializable]
    public struct PowerUp
    {
        public PowerUpLibrary powerUpName;
        public GameObject powerUpObj;
    }

    void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        StartCoroutine(PowerUpCheckRoutine());
    }

    public void SpawnNewPowerUp()
    {
        if (!powerUpSpawned)
        {
            powerUpSpawned = true;
            int index = UnityEngine.Random.Range(0, powerUpList.Count);                           //<<<<<<<<<<<<<<<<<<<<<<<<<<  PowerUp
            activePowerUp = powerUpList.Find(x => x.powerUpName == possiblePowerUps[index]);

            //float powerUpDuration = activePowerUp.powerUpObj.GetComponent<PowerUpBase>().duration;

            Vector2 spawnPos = SpawnPosition();
            activePowerUp.powerUpObj = Instantiate(activePowerUp.powerUpObj, spawnPos, Quaternion.identity);
            //StartCoroutine(ActivePowerUpTimerRoutine(powerUpDuration));
        }
    }

    public void StartPowerUpRoutine()
    {
        powerUpSpawned = false;
        StartCoroutine(PowerUpCheckRoutine());
    }

    public void PowerUpCollected(float duration)
    {
        powerUpOn = true;
        StartCoroutine(ActivePowerUpTimerRoutine(duration));
    }

    Vector2 SpawnPosition()
    {
        float rng = UnityEngine.Random.value;
        float y;
        float x;

        if (rng < 0.5f)
            y = -ySpawn;
        else
            y = ySpawn;

        x = UnityEngine.Random.Range(-xSpawn, xSpawn);

        Vector2 pos = new Vector2(x, y);
        return pos;
    }


    public IEnumerator ActivePowerUpTimerRoutine(float duration)
    {
        powerUpOn = true;

        while (powerUpOn)
        {
            yield return new WaitForSeconds(1);

            if (duration != 0)
            {
                duration--;
            }
            else
            {
                powerUpOn = false;
                activePowerUp.powerUpObj.GetComponent<PowerUpBase>().EndEffect();
                StartCoroutine(PowerUpCheckRoutine());
            }
        }
    }

    public IEnumerator PowerUpCheckRoutine()
    {
        spawnCooldown = UnityEngine.Random.Range(minSpawnCooldown, maxSpawnCooldown);

        while (!powerUpOn && !powerUpSpawned)
        {
            yield return new WaitForSeconds(1);

            if (spawnCooldown != 0)
            {
                spawnCooldown--;
            }
            else
            {
                SpawnNewPowerUp();
            }
        }
    }

}
