using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   public static bool deadEnemy=true;
    public GameObject Monster;
    private void Awake()
    {
        Spawn();
    }
    private void Update()
    {
        if (deadEnemy == true)
        Spawn();
        
    }
    void Spawn()
    {
        Vector3 posSpawn = new Vector3(Random.Range(-6f, 6f), transform.position.y, transform.position.z);
        Instantiate(Monster, posSpawn, Quaternion.identity);
        deadEnemy = false;
    }
}
