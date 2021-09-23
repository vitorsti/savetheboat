using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameLibrary;

public class Monster : MonoBehaviour
{
    public int life;

    public float speed;

    public int coinDrop;

    public EnemyType type;

    public SpawnPos spawnPos;

    public Transform boat;

    public virtual void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Player").transform;

        if (transform.position.x > SpawnPosXGap)
            spawnPos = SpawnPos.Ahead;
        else if (transform.position.x < -SpawnPosXGap)
            spawnPos = SpawnPos.Behind;
        else
            spawnPos = SpawnPos.Beside;

        if (transform.position.x > boat.transform.position.x)
            this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        else
            this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
    }

    public virtual void Attack()
    {

    }

    public virtual void Move()
    {
        //Look at target
        Vector2 direction = boat.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);

        //Go to target
        transform.position = Vector2.MoveTowards(transform.position, boat.position, speed * Time.deltaTime);
    }

    public virtual void RemoveHealth(int damage)
    {
        life -= damage;
        if (life <= 0)
            Destroy(this.gameObject);
    }
}
