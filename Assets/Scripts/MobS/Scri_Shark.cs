using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnumLibrary;

public class Scri_Shark : Monster
{
    //public Monster monsters;

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDestroy()
    {
        
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
