using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHurricane : EventBase
{
    [SerializeField] float speedMultiplier;

    public override void EventMechanic()
    {
        SpawnerManager.Instance.ChangeSpeedMultiplier(1, speedMultiplier);
    }

    public override void EventVisualEffect()
    {
        Debug.Log("HURRICANE");
    }

    public override void OnDestroy()
    {
        SpawnerManager.Instance.ChangeSpeedMultiplier();
    }

    public override void Start()
    {
        EventMechanic();
        EventVisualEffect();
    }
}
