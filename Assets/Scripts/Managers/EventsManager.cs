using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumLibrary;

public class EventsManager : MonoBehaviour
{
    public List<Event> eventList;

    [Serializable]
    public struct Event
    {
        public EventLibrary eventName;
        public GameObject eventObj;
    }

    void Start()
    {
        //StartCoroutine(EventCheckRoutine());
    }

    public IEnumerator EventCheckRoutine()
    {
        while (true)
        {     

        }
    }

}
