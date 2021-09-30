using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameLibrary
{

    public static float SpawnPosXGap = 0.25f;

    public static float ScreenSafetyPosX = 0.65f;

    public static Vector3 cameraPosAboveWater = new Vector3(0, 0.75f, 0);
    public static Vector3 cameraPosUnderWater = new Vector3(0, -0.75f, 0);

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

    public enum Region
    {
        Aerial,
        Aquatic,
        All
    }

    public enum PowerUpLibrary
    {
        CrimsonHeart,
        DavyJonesCoin,
        PoseidonsAmulet,
        MermaidsAmulet,
        AquaticScarecrow
    }

}