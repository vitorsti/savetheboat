using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventThunderstorm : EventBase
{
    [SerializeField] float speedMultiplier;
    [SerializeField] Color skyColor;
    [SerializeField] GameObject lightnings;

    public override void EventCameraPosition()
    {
        CameraController.Singleton.ChangeCameraPos(GameLibrary.cameraPosUnderWater);
    }

    public override void EventMechanic()
    {
        SpawnerManager.Instance.TurnOffSpawner(false, true);
        SpawnerManager.Instance.ChangeSpeedMultiplier(1, speedMultiplier);
    }

    public override void OnDestroy()
    {
        SpawnerManager.Instance.TurnOffSpawner(true, true);
        SpawnerManager.Instance.ChangeSpeedMultiplier();
        BackgroundHandler.Singleton.ToogleSkyCustomColor(false);
        CameraController.Singleton.ChangeCameraPos(Vector2.zero);
    }

    public override void EventVisualEffect()
    {
        BackgroundHandler.Singleton.ChangeSkyCustomColor(skyColor);
        BackgroundHandler.Singleton.ToogleSkyCustomColor(true);
    }

    public override void Start()
    {
        EventVisualEffect();
        EventCameraPosition();
        EventMechanic();
    }
}
