using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHurricane : EventBase
{
    [SerializeField] float speedMultiplier;
    [SerializeField] Color skyColor;

    public override void EventMechanic()
    {
        SpawnerManager.Instance.ChangeSpeedMultiplier(1, speedMultiplier);
    }

    public override void EventVisualEffect()
    {
        BackgroundHandler.Singleton.ChangeSkyCustomColor(skyColor);
        BackgroundHandler.Singleton.ToogleSkyCustomColor(true);
    }

    public override void OnDestroy()
    {
        BackgroundHandler.Singleton.ToogleSkyCustomColor(false);
        SpawnerManager.Instance.ChangeSpeedMultiplier();
    }

    public override void Start()
    {
        EventMechanic();
        EventVisualEffect();
    }
}
