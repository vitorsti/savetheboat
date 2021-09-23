using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLibrary
{
    public enum EnemyType
    {
        Aerial,
        Aquatic
    }

    public enum SpawnPos
    {
        Behind,
        Beside,
        Ahead
    }

    public enum EventLibrary
    {
        RedTide,
        Sharknado,
        Fog,
        Hurricane,
        SandStorm,
        Thunderstorm
    }

    public enum EventRegion
    {
        Aerial,
        Aquatic,
        All
    }

    public static float SpawnPosXGap = 0.25f;
}