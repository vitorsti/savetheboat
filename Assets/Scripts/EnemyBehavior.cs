using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Transform player;
    public float speed;
    public float rotationSpeed;
    public GameObject prefab;
    public string postionName;
    public float screenSide;
    public Vector3 scrPos;
    Transform position;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (postionName != "")
        {
            position = GameObject.Find(postionName).GetComponent<Transform>();
        }

        screenSide = Screen.width / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Look at target
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //Go to target
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);



        //flips sprite
        scrPos = Camera.main.WorldToScreenPoint(transform.position);

        if (scrPos.x > screenSide)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else
            this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;

    }

    void OnMouseDown()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // if (prefab == null)
            // {

            //     Destroy(this.gameObject);
            // }
            // else if (prefab != null)
            // {
            if (prefab != null)
            {
                GameObject go = Instantiate(prefab, position.position, position.rotation, position.parent);
                go.name = prefab.name;
                Destroy(this.gameObject);
            }
            else
            {
                HealthManager.RemoveHealth();
                Destroy(this.gameObject);
            }
        }
    }

}
