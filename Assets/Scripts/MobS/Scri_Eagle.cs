using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using static GameLibrary;

public class Scri_Eagle : Monster
{
    private void FixedUpdate()
    {
        //Move();
    }
    /*
        public override void Move()
        {
            //Look at target
            Vector2 direction = boat.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);

            //Go to target
            //transform.position = Vector2.MoveTowards(transform.position, boat.position, speed * Time.deltaTime);
            transform.position = Vector2.Lerp(transform.position, boat.position, speed * Time.deltaTime);
        }

    */

    public override void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Player").transform;

        if (transform.position.x > SpawnPosXGap)
            spawnPos = SpawnPos.Ahead;
        else if (transform.position.x < -SpawnPosXGap)
            spawnPos = SpawnPos.Behind;
        else
            spawnPos = SpawnPos.Beside;

        if (transform.position.x > boat.transform.position.x)
            //    this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            gameObject.transform.DORotate(new Vector3(0, 180, 0), 0.1f, RotateMode.Fast);
        //else
        //    this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;


        Move();

    }

    public override void Move()
    {
        StartCoroutine(EagleMove());
    }

    IEnumerator EagleMove()
    {

        if (transform.position.y < 0)
        {
            //Isso não pode acontecer
            Destroy(gameObject);
        }
        else
        {
            if (transform.position.x > boat.transform.position.x)
            {

                Vector3 endPoint = new Vector3(-gameObject.transform.position.x - 1.5f, boat.transform.position.y + 0.2f, 0);

                Vector3[] wayPoints = new Vector3[]
                {                                     
                /*P2*/  new Vector3(boat.transform.position.x + 0.25f, boat.transform.position.y + 0.25f ,0),
                /*A*/   new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f ,0),
                /*B*/   new Vector3(boat.transform.position.x + 0.5f, boat.transform.position.y + 0.1f ,0),
                /*P3*/  //new Vector3(-gameObject.transform.position.x, boat.transform.position.y + 0.15f ,0), 
                /*C*/   //new Vector3(boat.transform.position.x - 0.5f, boat.transform.position.y + 0.1f ,0), 
                /*D*/   //new Vector3(-gameObject.transform.position.x - 0.5f, boat.transform.position.y -0.15f ,0)

                };

                gameObject.transform.DOPath(wayPoints, 2f, PathType.CubicBezier, PathMode.Full3D, 10, Color.black);

                yield return new WaitForSeconds(1.85f);

                gameObject.transform.DOLocalMove(endPoint, 1.25f, false);

                yield return new WaitForSeconds(5f);

                Destroy(gameObject);

            }
            else
            {

                Vector3 endPoint = new Vector3(-gameObject.transform.position.x + 1.5f, boat.transform.position.y + 0.2f, 0);

                Vector3[] wayPoints = new Vector3[]
                {                                     
                /*P2*/  new Vector3(boat.transform.position.x - 0.25f, boat.transform.position.y + 0.25f ,0),
                /*A*/   new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f ,0),
                /*B*/   new Vector3(boat.transform.position.x - 0.5f, boat.transform.position.y + 0.1f ,0),
                /*P3*/  //new Vector3(-gameObject.transform.position.x, boat.transform.position.y + 0.15f ,0), 
                /*C*/   //new Vector3(boat.transform.position.x - 0.5f, boat.transform.position.y + 0.1f ,0), 
                /*D*/   //new Vector3(-gameObject.transform.position.x - 0.5f, boat.transform.position.y -0.15f ,0)

                };

                gameObject.transform.DOPath(wayPoints, 2f, PathType.CubicBezier, PathMode.Full3D, 10, Color.black);

                yield return new WaitForSeconds(1.85f);

                gameObject.transform.DOLocalMove(endPoint, 1.25f, false);

                yield return new WaitForSeconds(5f);

                Destroy(gameObject);

            }
        }
    }

}
