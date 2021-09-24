using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameLibrary;

public abstract class EventBase : MonoBehaviour
{
    public int eventDuration = 15;

    public EventRegion eventType;

    public abstract void EventVisualEffect();

    public virtual void EventCameraPosition() { }

    public virtual void EventMechanic() { }

    public abstract void OnDestroy();

    public abstract void Start();
}
