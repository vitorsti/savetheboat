using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnSpeed;
    GameObject thisObt;
    // Start is called before the first frame update
    void Start()
    {
        thisObt = this.gameObject;

        InvokeRepeating("Spawn", 1f, 1f);
    }

    public void Spawn()
    {
        GameObject go = Instantiate(enemyPrefab, thisObt.transform.position, thisObt.transform.rotation, thisObt.transform);
        go.name = enemyPrefab.name;
    }
}
