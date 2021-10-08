using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDavyJonesCoin : PowerUpBase
{
    public int multiplier;

    public override void ActivatePowerUp()
    {
        collected = true;
        StopAllCoroutines();
        StartCoroutine(GoToBoat());
        GameManager.Singleton.ChangeCoinMultiplier(multiplier);
        PowerUpManager.Singleton.PowerUpCollected(duration);
        Debug.Log(gameObject.name);
    }

    public override void EndEffect()
    {
        GameManager.Singleton.ChangeCoinMultiplier();
        Destroy(gameObject);
    }
}
