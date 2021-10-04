using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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

        //indx 0 -> Parachute
        //indx 1 -> Bubble
        //indx 2 -> Amulet 
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);

        boat = GameObject.FindGameObjectWithTag("Player").transform;

        if (transform.position.y > 0)
        {
            y = -3;

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);


            StartCoroutine(ParachuteMove());

        }
        else
        {
            StartCoroutine(BubbleMove());
        }


        target = new Vector2(x, y);
    }

    public virtual void Update()
    {
        //if(!collected)
            //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.1f)
            Destroy(gameObject);
    }

    public abstract void ActivatePowerUp();

    public virtual void EndEffect() { }

    IEnumerator ParachuteMove()
    {
        Vector3[] wayPoints = new Vector3[] {   new Vector3(target.x         , 3.0f ,-1), 
                                                new Vector3(target.x - 0.125f, 2.5f ,-1),
                                                new Vector3(target.x + 0.125f, 2.0f ,-1),
                                                new Vector3(target.x - 0.125f, 1.5f ,-1),
                                                new Vector3(target.x + 0.125f, 1.0f ,-1),
                                                new Vector3(target.x - 0.125f, 0.75f,-1)};

        yield return new WaitForSeconds(0.1f);

        gameObject.transform.DOPath(wayPoints, 4, PathType.CubicBezier, PathMode.Full3D, 10, Color.magenta);

        yield return new WaitForSeconds(4f);

        gameObject.transform.DOLocalMove(new Vector3(-ScreenSafetyPosX, 1, -1), 1.5f, false);
    }


    IEnumerator BubbleMove()
    {
        Vector3[] wayPoints = new Vector3[] {   new Vector3(transform.position.x         , -3.0f ,-1),
                                                new Vector3(transform.position.x - 0.125f, -2.5f ,-1),
                                                new Vector3(transform.position.x + 0.125f, -2.0f ,-1),
                                                new Vector3(transform.position.x - 0.125f, -1.5f ,-1),
                                                new Vector3(transform.position.x + 0.125f, -1.0f ,-1),
                                                new Vector3(transform.position.x - 0.125f, -0.5f,-1)};

        yield return new WaitForSeconds(0.1f);

        gameObject.transform.DOPath(wayPoints, 4, PathType.CubicBezier, PathMode.Full3D, 10, Color.magenta);

        yield return new WaitForSeconds(4f);

        gameObject.transform.DOLocalMove(new Vector3(-ScreenSafetyPosX, -1, -1), 1.5f, false);
    }
}
