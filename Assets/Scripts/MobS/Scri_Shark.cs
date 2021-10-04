using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static GameLibrary;

public class Scri_Shark : Monster
{
    //public Monster monsters;
    private void Start()
    {
        Move();    
    }

    public override void Move()
    {
        StartCoroutine(SharkMove());
    }

    IEnumerator SharkMove()
    {
        if (transform.position.x > boat.transform.position.x)
        {
            Vector3[] wayPoints = new Vector3[]
            {                                     
                                                /*P1*/  //new Vector3(gameObject.transform.position.x         , 3.0f ,-1),
                                                /*P2*/  new Vector3(boat.transform.position.x, boat.transform.position.y - 0.275f ,0),
                                                /*A*/   new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f ,0),
                                                /*B*/   new Vector3(boat.transform.position.x + 0.5f, boat.transform.position.y -0.275f ,0),
                                                /*P3*/  new Vector3(-gameObject.transform.position.x, gameObject.transform.position.y ,0), 
                                                /*C*/   new Vector3(boat.transform.position.x - 0.5f, boat.transform.position.y - 0.275f ,0), 
                                                /*D*/   new Vector3(-gameObject.transform.position.x, gameObject.transform.position.y+0.5f ,0)

            };
        }

        yield return new WaitForSeconds(1f);

    }

    //public float Speed { get; set; }
    //public int CoinDrop { get; set; }
    //public int Life { get; set; }
    //public EnemyType Type { get; set; }
    //public SpawnPos spawnPos { get; set; }
    //public Transform boat;

    ////Use for starting Values from inspector
    //[SerializeField] int _life;
    //[SerializeField] float _speed;
    //[SerializeField] int _coinDrop;
    //[SerializeField] EnemyType _type;

    //public void Attack()
    //{

    //}

    //public void Move()
    //{
    //    //Look at target
    //    Vector2 direction = boat.position - transform.position;
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);

    //    //Go to target
    //    transform.position = Vector2.MoveTowards(transform.position, boat.position, Speed * Time.deltaTime);
    //}

    //public void RemoveHealth(int damage)
    //{
    //    Life -= damage;
    //    if (Life <= 0)
    //        Destroy(this.gameObject);
    //}

    //void Start()
    //{
    //    boat = GameObject.FindGameObjectWithTag("Player").transform;

    //    Speed = _speed;
    //    CoinDrop = _coinDrop;
    //    Life = _life;

    //    if (transform.position.x > SpawnPosXGap)
    //        spawnPos = SpawnPos.Ahead;
    //    else if (transform.position.x < -SpawnPosXGap)
    //        spawnPos = SpawnPos.Behind;
    //    else
    //        spawnPos = SpawnPos.Beside;

    //    if (transform.position.x > boat.transform.position.x)
    //        this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
    //    else
    //        this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
    //}

    //public void FixedUpdate()
    //{
    //    Move();
    //    Debug.Log(gameObject.name + Life);
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        HealthManager.RemoveHealth();
    //        Destroy(this.gameObject);
    //    }
    //}

    //public void OnDestroy()
    //{

    //}
}
