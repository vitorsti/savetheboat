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

    public abstract void EventMechanic();

    public virtual void Start() { Debug.Log("Spawnou " + eventType + eventDuration); }
}
