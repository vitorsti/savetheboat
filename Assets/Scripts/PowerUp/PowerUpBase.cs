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
        //if(collected)
            //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if (Vector2.Distance(transform.position, target) < 0.1f)
            //Destroy(gameObject);
    }

    public abstract void ActivatePowerUp();

    public virtual void EndEffect() { }

    IEnumerator ParachuteMove()
    {
        Vector3[] wayPoints = new Vector3[] 

        {                                     
                                                /*P1*/  //new Vector3(gameObject.transform.position.x         , 3.0f ,-1),
                                                /*P2*/  new Vector3(gameObject.transform.position.x - 0.125f, 2.5f ,-1),
                                                /*A*/   new Vector3(gameObject.transform.position.x         , 2.9f ,-1),
                                                /*B*/   new Vector3(gameObject.transform.position.x         , 2.5f ,-1),
                                                /*P3*/  new Vector3(gameObject.transform.position.x + 0.125f, 2.0f ,-1), 
                                                /*C*/   new Vector3(gameObject.transform.position.x - 0.125f, 2.4f ,-1), 
                                                /*D*/   new Vector3(gameObject.transform.position.x         , 2.0f ,-1), 
                                                /*P4*/  new Vector3(gameObject.transform.position.x - 0.125f, 1.5f ,-1),
                                                /*E*/   new Vector3(gameObject.transform.position.x + 0.125f, 1.9f ,-1), 
                                                /*F*/   new Vector3(gameObject.transform.position.x         , 1.5f ,-1),
                                                /*P5*/  new Vector3(gameObject.transform.position.x + 0.125f, 1.0f ,-1),
                                                /*G*/   new Vector3(gameObject.transform.position.x - 0.125f, 1.4f ,-1),
                                                /*H*/   new Vector3(gameObject.transform.position.x         , 1.0f ,-1),
                                                /*P6*/  new Vector3(gameObject.transform.position.x - 0.125f, 0.5f,-1),
                                                /*I*/   new Vector3(gameObject.transform.position.x + 0.125f, 0.9f ,-1),
                                                /*J*/   new Vector3(gameObject.transform.position.x         , 0.5f ,-1)
        };



        yield return new WaitForSeconds(0.1f);

        gameObject.transform.DOPath(wayPoints, 10, PathType.CubicBezier, PathMode.Full3D, 10, Color.magenta);

        yield return new WaitForSeconds(9f);

        gameObject.transform.DOLocalMove(new Vector3(gameObject.transform.position.x - 3f, 1, -1), 4f, false);

        yield return new WaitForSeconds(4.25f);

        Destroy(gameObject);
    }

    IEnumerator BubbleMove()
    {
        Vector3[] wayPoints = new Vector3[] {   
                                                /*P1*/  //new Vector3(gameObject.transform.position.x         , -3.0f ,-1),
                                                /*P2*/  new Vector3(gameObject.transform.position.x - 0.125f, -2.5f ,-1),
                                                /*A*/   new Vector3(gameObject.transform.position.x - 0.125f, -3f, -1),
                                                /*B*/   new Vector3(gameObject.transform.position.x - 0.125f, -2.625f, -1),
                                                /*P3*/  new Vector3(gameObject.transform.position.x + 0.125f, -2.0f ,-1), 
                                                /*C*/   new Vector3(gameObject.transform.position.x - 0.125f, -2.375f, -1), 
                                                /*D*/   new Vector3(gameObject.transform.position.x + 0.125f, -2.125f, -1), 
                                                /*P4*/  new Vector3(gameObject.transform.position.x - 0.125f, -1.5f ,-1),
                                                /*E*/   new Vector3(gameObject.transform.position.x + 0.125f, -1.875f, -1), 
                                                /*F*/   new Vector3(gameObject.transform.position.x - 0.125f, -1.625f, -1),
                                                /*P5*/  new Vector3(gameObject.transform.position.x + 0.125f, -1.0f ,-1),
                                                /*G*/   new Vector3(gameObject.transform.position.x - 0.125f, -1.375f, -1),
                                                /*H*/   new Vector3(gameObject.transform.position.x + 0.125f, -1.125f, -1),
                                                /*P6*/  new Vector3(gameObject.transform.position.x - 0.125f, -0.5f,-1),
                                                /*I*/   new Vector3(gameObject.transform.position.x + 0.125f, -0.875f, -1),
                                                /*J*/   new Vector3(gameObject.transform.position.x - 0.125f, -0.625f, -1)

        };

        yield return new WaitForSeconds(0.1f);

        gameObject.transform.DOPath(wayPoints, 6, PathType.CubicBezier, PathMode.Full3D, 10, Color.magenta);

        yield return new WaitForSeconds(6f);

        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.DOLocalMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f, -1), 0.25f, false);
        yield return new WaitForSeconds(0.25f);
        gameObject.transform.DOLocalMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 3.0f, -1), 2f, false);
        yield return new WaitForSeconds(2.25f);

        Destroy(gameObject);

    }

    public IEnumerator GoToBoat()
    {
        gameObject.transform.DOKill();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.DOScale(0.75f, 1f);
        gameObject.transform.DOLocalMove(new Vector3(boat.transform.position.x, boat.transform.position.y + 0.075f, -1),1, false);
        gameObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1f);
        yield return new WaitForSeconds(1.0f);

    }
}
