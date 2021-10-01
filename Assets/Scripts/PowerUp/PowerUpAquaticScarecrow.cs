using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAquaticScarecrow : PowerUpBase
{
    public float speedDivider;

    public override void ActivatePowerUp()
    {
        collected = true;
        SpawnerManager.Instance.ChangeSpeedMultiplier(speedDivider, 1);
        PowerUpManager.Singleton.PowerUpCollected(duration);
        Debug.Log(gameObject.name);
    }

    public override void EndEffect()
    {
        SpawnerManager.Instance.ChangeSpeedMultiplier();
        PowerUpManager.Singleton.StartPowerUpRoutine();
        Destroy(gameObject);
    }
}
