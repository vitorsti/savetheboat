using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPoseidonsAmulet : PowerUpBase
{
    BoatController boatController;

    public override void ActivatePowerUp()
    {
        collected = true;
        StopAllCoroutines();
        StartCoroutine(GoToBoat());
        boatController = GameObject.FindGameObjectWithTag("Player").GetComponent<BoatController>();
        PowerUpManager.Singleton.PowerUpCollected(duration);
        boatController.TurnInvencible(true);
        Debug.Log(gameObject.name);
    }

    public override void EndEffect()
    {
        boatController.TurnInvencible(false);
        Destroy(gameObject);
    }
}
