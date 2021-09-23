using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameLibrary;

public class EventsManager : MonoBehaviour
{
    public float eventCooldown;

    public bool eventOn;
    public Event activeEvent;

    public List<Event> eventList;

    [Serializable]
    public struct Event
    {
        public EventLibrary eventName;
        public GameObject eventObj;
    }

    void Start()
    {
        StartCoroutine(EventCheckRoutine());
    }

    public void StartNewEvent()
    {
        if (!eventOn)
        {
            int index = 1;//UnityEngine.Random.Range(0, eventList.Count);
            activeEvent = eventList[index];
            //int eventDuration = eventList[index].eventObj.GetComponent<EventBase>().eventDuration;
            int eventDuration = activeEvent.eventObj.GetComponent<EventBase>().eventDuration;
            activeEvent.eventObj = Instantiate(activeEvent.eventObj, transform.parent);
            StartCoroutine(ActiveEventTimerRoutine(eventDuration));
        }
    }


    public IEnumerator ActiveEventTimerRoutine(int duration)
    {
        eventOn = true;

        while (eventOn)
        {
            yield return new WaitForSeconds(1);

            if (duration != 0)
            {
                duration--;
            }
            else
            {
                Destroy(activeEvent.eventObj);
                eventCooldown = 15;
                eventOn = false;
                StartCoroutine(EventCheckRoutine());
                //StopCoroutine(ActiveEventTimerRoutine(0));
            }
        }
    }

    public IEnumerator EventCheckRoutine()
    {
        while (!eventOn)
        {
            yield return new WaitForSeconds(1);

            if (eventCooldown != 0)
            {
                eventCooldown--;
            }
            else
            {
                StartNewEvent();
            }
        }
    }

}
