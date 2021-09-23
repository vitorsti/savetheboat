using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBase : MonoBehaviour
{
    public int eventDuration = 15;

    public abstract void EventVisualEffect();

    public virtual void EventCameraPosition() { }

    public abstract void EventMechanic();
}
