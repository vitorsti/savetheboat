using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSandStorm : EventBase
{
    [SerializeField] float speedMultiplier;
    [SerializeField] Color skyColor;
    [SerializeField] Color waterColor;

    public override void EventMechanic()
    {
        SpawnerManager.Instance.ChangeSpeedMultiplier(speedMultiplier, 1);
    }

    public override void EventVisualEffect()
    {
        BackgroundHandler.Singleton.ChangeSkyCustomColor(skyColor);
        BackgroundHandler.Singleton.ToogleSkyCustomColor(true);
        BackgroundHandler.Singleton.ChangeWaveCustomColor(waterColor);
        BackgroundHandler.Singleton.ToogleWaveCustomColor(true);
    }

    public override void OnDestroy()
    {
        BackgroundHandler.Singleton.ToogleSkyCustomColor(false);
        BackgroundHandler.Singleton.ToogleWaveCustomColor(false);
        SpawnerManager.Instance.ChangeSpeedMultiplier();
    }

    public override void Start()
    {
        EventMechanic();
        EventVisualEffect();
    }
}
