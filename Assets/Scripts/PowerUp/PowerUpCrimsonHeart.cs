using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCrimsonHeart : PowerUpBase
{
    public int recoveryAmount;

    public override void ActivatePowerUp()
    {
        collected = true;
        StopAllCoroutines();
        StartCoroutine(GoToBoat());
        BoatController boat = GameObject.FindGameObjectWithTag("Player").GetComponent<BoatController>();
        boat.HealHealth(recoveryAmount);
        Destroy(gameObject);
        Debug.Log(gameObject.name);
    }
}
