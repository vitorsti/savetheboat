using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawn : MonoBehaviour
{
    public string objName, spawnTrigger;
    [SerializeField] GameObject prefab;
    public Transform spawner;

    public Vector3 _offSetSpawn;

    //public bool usingCustomColor;
    public GameObject lastSpawned;

    void Awake(){
        if(spawner == null)
            spawner = GameObject.Find("BgSpawner").transform;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == spawnTrigger)
        {
            //Destroy(other.gameObject);

            lastSpawned = Instantiate(prefab, new Vector3(spawner.position.x + _offSetSpawn.x,
                spawner.position.y +_offSetSpawn.y
                ,spawner.position.z + _offSetSpawn.z), Quaternion.identity);

            lastSpawned.transform.SetParent(spawner.gameObject.transform, true);
            lastSpawned.name = objName;

            if(objName == "Waves Paralax")
            {
                gameObject.GetComponentInParent<BackgroundHandler>().lastWave = lastSpawned.gameObject;
            }
        }

    }

}
