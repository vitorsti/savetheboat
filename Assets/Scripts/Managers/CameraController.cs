using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Singleton { get; private set; }

    [SerializeField] float speed;
    Vector3 targetPos;
    Vector3 velocity;
    bool called;

    void Awake()
    {
        Singleton = this;
        //DontDestroyOnLoad(gameObject);
    }

    public void ChangeCameraPos(Vector2 newPos)
    {
        targetPos = new Vector3(newPos.x, newPos.y, -10);
        called = true;
    }

    private void Update()
    {
        if (called)
        {
            if (Vector2.Distance(transform.position, targetPos) > 0.01f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, speed);
            }
            else
                called = false;
        }
    }
}
