using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRedTide : EventBase
{
    [SerializeField] float speedMultiplier;
    [SerializeField] float strenghtMultiplier;
    [SerializeField] Color waterColor;
    [SerializeField] Color skyColor;

    public override void EventCameraPosition()
    {
        CameraController.Singleton.ChangeCameraPos(GameLibrary.cameraPosUnderWater);
    }

    public override void EventMechanic()
    {
        SpawnerManager.Instance.TurnOffSpawner(false, true);
        float rng = Random.value;

        if(rng < 0.5f)
            SpawnerManager.Instance.ChangeSpeedMultiplier(1, speedMultiplier);
        else
            SpawnerManager.Instance.ChangeStrenghtMultiplier(1, strenghtMultiplier);
    }

    public override void OnDestroy()
    {
        SpawnerManager.Instance.TurnOffSpawner(true, true);
        SpawnerManager.Instance.ChangeSpeedMultiplier();
        SpawnerManager.Instance.ChangeStrenghtMultiplier();
        BackgroundHandler.Singleton.ToogleWaveCustomColor(false);
        BackgroundHandler.Singleton.ToogleSkyCustomColor(false);
        CameraController.Singleton.ChangeCameraPos(Vector2.zero);
    }

    public override void EventVisualEffect()
    {
        BackgroundHandler.Singleton.ChangeWaveCustomColor(waterColor);
        BackgroundHandler.Singleton.ChangeSkyCustomColor(skyColor);
        BackgroundHandler.Singleton.ToogleSkyCustomColor(true);
        BackgroundHandler.Singleton.ToogleWaveCustomColor(true);
    }

    public override void Start()
    {
        EventVisualEffect();
        EventCameraPosition();
        EventMechanic();
    }
}
