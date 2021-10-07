using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSharknado : EventBase
{
    public SpriteRenderer bg;
    [SerializeField] int sharkSpeedMultiplier = 2;
    public List<GameObject> eventMobs;

    [SerializeField] Color skyColor;
    [SerializeField] Color waterColor;


    public override void EventMechanic()
    {
        SpawnerManager.Instance.ChangeSpawnerToCustomList(eventMobs, eventMobs);
        SpawnerManager.Instance.ChangeSpeedMultiplier(sharkSpeedMultiplier, sharkSpeedMultiplier);
    }

    public override void EventVisualEffect()
    {
        bg = Instantiate(bg, transform);
        BackgroundHandler.Singleton.ChangeSkyCustomColor(skyColor);
        BackgroundHandler.Singleton.ToogleSkyCustomColor(true);
        //bg.sortingOrder = 75;
    }

    public override void OnDestroy()
    {
        SpawnerManager.Instance.ChangeSpeedMultiplier(1, 1);
        BackgroundHandler.Singleton.ToogleSkyCustomColor(false);
        SpawnerManager.Instance.ChangeUsingCustomList(false, false);
    }

    public override void Start()
    {
        EventVisualEffect();
        EventMechanic();
    }

}
