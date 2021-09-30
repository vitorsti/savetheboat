using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DifficultyHandler;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }

    public int monsterCount;

    public int coins;
    [SerializeField] int coinsMultiplier = 1;

    public float boatSpeed;
    public float speedMultiplier;

    GameObject boat;

    [SerializeField] DifficultyHandler difficulty;
    [SerializeField] LevelProperties actualLevel;

    void Awake()
    {
        Singleton = this;
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Player");
        monsterCount = 0;
        coinsMultiplier = 1;
        boatSpeed = boat.GetComponent<BoatController>().boatSpeed;
        Invoke("SetNewLevel", 0.5f);
    }

    public void MonsterKill()
    {
        monsterCount++;

        if (difficulty.HasToChangeLevel(monsterCount))
        {
            SetNewLevel();
        }
    }

    public void SetNewLevel()
    {
        actualLevel = difficulty.CheckLevelToChange(monsterCount);

        if (actualLevel != null)
        {
            if (actualLevel.aerialSpawner)
            {
                SpawnerManager.Instance.aerialSpawner.GetComponent<MobSpawner>().SetListOfMobs(actualLevel.aerialList);
            }

            if (actualLevel.aquaticSpawner)
            {
                SpawnerManager.Instance.aquaticSpawner.GetComponent<MobSpawner>().SetListOfMobs(actualLevel.aquaticList);
            }

            EventsManager.Singleton.SetNewEventList(actualLevel.events);
            SpawnerManager.Instance.SetSpawnQuantityLimit(actualLevel.spawnQtdLimit);
            SpawnerManager.Instance.SetSpawnerCooldowns(actualLevel.spawnCycleCd, actualLevel.spawnCd);
        }
    }

    public void IncreaseCoin(int _coins)
    {
        coins += (_coins * coinsMultiplier);
    }

    public void ChangeCoinMultiplier(int value = 1)
    {
        coinsMultiplier = value;
    }

    public void ChangeSpeedMultiplier(int value = 1)
    {
        speedMultiplier = value;
    }

    void Update()
    {
        
    }
}
