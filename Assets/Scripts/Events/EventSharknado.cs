using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSharknado : EventBase
{
    public SpriteRenderer bg;
    [SerializeField] int sharkSpeedMultiplier = 2;
    SpawnerManager spawnerManager;
    public List<GameObject> eventMobs;

    public override void EventMechanic()
    {
        spawnerManager.ChangeSpawnerToCustomList(eventMobs, eventMobs);
        spawnerManager.ChangeSpeedMultiplier(sharkSpeedMultiplier, sharkSpeedMultiplier);
    }

    public override void EventVisualEffect()
    {
        bg = Instantiate(bg, transform);
        //bg.sortingOrder = 75;
    }

    private void OnDestroy()
    {
        spawnerManager.ChangeSpeedMultiplier(1, 1);
        spawnerManager.ChangeUsingCustomList(false, false);
    }

    void Start()
    {
        EventVisualEffect();
        spawnerManager = FindObjectOfType<SpawnerManager>();

        EventMechanic();
    }

}
