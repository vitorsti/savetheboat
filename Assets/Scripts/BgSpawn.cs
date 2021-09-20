﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawn : MonoBehaviour
{
    public string objName, spawnTrigger;
    public GameObject prefab;
    public Transform spawn;

    void Awake(){
        spawn = GameObject.Find("BgSpawner").transform;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == spawnTrigger)
        {
            //Destroy(other.gameObject);

            GameObject go = Instantiate(prefab, new Vector3(spawn.position.x + 0.2f,spawn.position.y + 0.03f,spawn.position.z), Quaternion.identity);
            go.transform.SetParent(spawn.gameObject.transform, true);
            go.name = objName;

        }

    }

}
