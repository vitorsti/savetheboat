using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameLibrary;

public abstract class PowerUpBase : MonoBehaviour
{
    public int duration;

    public bool collected;

    public SpawnPos spawnPos;

    public Region region;

    public Transform boat;

    [SerializeField] float speed = 0.2f;
    [SerializeField] Vector2 target;

    public virtual void OnDestroy()
    {
        if (collected)
        {
            
        }

        PowerUpManager.Singleton.StartPowerUpRoutine();
    }

    public virtual void Start() 
    {
        speed = 0.2f;
        float x = Random.Range(-ScreenSafetyPosX, ScreenSafetyPosX);
        float y = 3;

        boat = GameObject.FindGameObjectWithTag("Player").transform;

        if (transform.position.y > 0)
        {
            y = -3;
        }

        target = new Vector2(x, y);
    }

    public virtual void Update()
    {
        if(!collected)
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.1f)
            Destroy(gameObject);
    }

    public abstract void ActivatePowerUp();

    public virtual void EndEffect() { }
}
