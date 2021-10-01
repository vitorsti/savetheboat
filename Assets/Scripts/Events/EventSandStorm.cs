using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSandStorm : EventBase
{
    [SerializeField] float speedMultiplier;

    public override void EventMechanic()
    {
        SpawnerManager.Instance.ChangeSpeedMultiplier(speedMultiplier, 1);
    }

    public override void EventVisualEffect()
    {
        Debug.Log("Sand Storm");
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
