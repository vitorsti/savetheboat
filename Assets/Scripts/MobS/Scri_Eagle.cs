using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scri_Eagle : Monster
{
    private void FixedUpdate()
    {
        Move();
    }

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
}
