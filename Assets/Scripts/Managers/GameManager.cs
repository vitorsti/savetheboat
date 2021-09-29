using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DifficultyHandler;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }

    public int monsterCount;

    [SerializeField] DifficultyHandler difficulty;

    [SerializeField] LevelProperties actualLevel;

    void Awake()
    {
        Singleton = this;
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        monsterCount = 0;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
