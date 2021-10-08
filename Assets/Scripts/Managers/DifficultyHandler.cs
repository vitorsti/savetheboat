using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameLibrary;

[CreateAssetMenu(menuName = "Handlers/Difficulty")]
public class DifficultyHandler : ScriptableObject
{
    public List<LevelProperties> levels;

    [Serializable]
    public class LevelProperties
    {
        public int killsToReach;

        public int spawnQtdLimit;
        public float spawnCycleCd;
        public float spawnCd;

        public bool aerialSpawner = true;
        public List<GameObject> aerialList;

        public bool aquaticSpawner = true;
        public List<GameObject> aquaticList;

        public List<EventLibrary> events;
    }

    public LevelProperties CheckLevelToChange(int kills)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].killsToReach == kills)
            {
                return levels[i];
            }
        }

        return null;
    }

    public bool HasToChangeLevel(int kills)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].killsToReach == kills)
            {
                return true;
            }
        }

        return false;
    }
}
