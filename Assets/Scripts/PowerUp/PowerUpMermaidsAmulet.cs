using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMermaidsAmulet : PowerUpBase
{
    public int multiplier;

    public override void ActivatePowerUp()
    {
        collected = true;
        StopAllCoroutines();
        StartCoroutine(GoToBoat());
        GameManager.Singleton.ChangeSpeedMultiplier(multiplier);
        PowerUpManager.Singleton.PowerUpCollected(duration);
        Debug.Log(gameObject.name);
    }

    public override void EndEffect()
    {
        GameManager.Singleton.ChangeSpeedMultiplier();
        Destroy(gameObject);
    }
}
