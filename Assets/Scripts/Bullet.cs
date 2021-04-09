using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Transform player;
    new Rigidbody2D rigidbody2D;
    private float bulSpeed = 4f;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
       // player = GameObject.FindWithTag("Weapon").transform;
        rigidbody2D.velocity = transform.right * bulSpeed;
        Destroy(this.gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(1);
            Destroy(this.gameObject);          
        }
       
    }

}
