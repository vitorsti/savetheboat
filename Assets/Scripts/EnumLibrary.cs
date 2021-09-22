using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class EnumLibrary
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

    public static float SpawnPosXGap = 0.25f;
}