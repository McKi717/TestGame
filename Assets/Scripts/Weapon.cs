using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{ 
    Transform enemy;
    public GameObject Bullet;

    float timeGame;
    private void Update()

    {
        timeGame += Time.deltaTime;
   
        GameObject Frog = GameObject.FindGameObjectWithTag("Enemy");
        enemy = Frog.transform;
        if (Vector3.Distance(enemy.position, transform.position) <= 6&&timeGame>1.5f) 
        Shoot();
    }
    void Shoot()
    {
        Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
        timeGame = 0;
    }
}
