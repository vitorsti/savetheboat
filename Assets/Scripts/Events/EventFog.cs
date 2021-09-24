using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFog : EventBase
{
    public GameObject fog;

    public override void EventCameraPosition()
    {
        CameraController.Singleton.ChangeCameraPos(GameLibrary.cameraPosAboveWater);
    }

    public override void EventVisualEffect()
    {
        fog = Instantiate(fog, transform);
    }

    public override void OnDestroy()
    {
        CameraController.Singleton.ChangeCameraPos(Vector2.zero);
        Destroy(fog);
    }

    public override void Start()
    {
        EventVisualEffect();
        EventCameraPosition();
    }
}
