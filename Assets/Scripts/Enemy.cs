using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int maxHealth = 2;
    private int currentHealth { get; set; }


    Transform frogTransform;

    private bool right = true;

    private float speed = 1.5f;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2d;
    new Collider2D collider2D;


    private void Start()
    {
        currentHealth = maxHealth;
        
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }


    private void Update()
    {
        GameObject Frog = GameObject.Find("Frog");
        frogTransform = Frog.transform;
        //Брождение
        if (Vector3.Distance(transform.position, frogTransform.position) >= 5)
        {
            if (right)
            {
                transform.Translate(Vector2.right * Time.deltaTime);
            }
            else transform.Translate(-Vector2.right * Time.deltaTime);


            if (transform.position.x >= 9)
            {
                FlipRight();
            }


            if (transform.position.x <= 5)
            {
                FlipLeft();
            }
        }

        //обнаружение героя
        Vector3 frogPos = transform.InverseTransformPoint(frogTransform.position);
        if (Vector3.Distance(transform.position, frogTransform.position) <= 5 && frogPos.x > 0)
        {
            FlipLeft();
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        else if (Vector3.Distance(transform.position, frogTransform.position) <= 5 && frogPos.x < 0)
        {
            FlipRight();
            transform.Translate(-Vector2.right * Time.deltaTime * speed);
        }

        //смерть при падении в пропасть
        if (transform.position.y < -10)
        {
            Dead();
        }

    }

   void FlipRight()
    {
        spriteRenderer.flipX = true;
        right = false;
    }
    void FlipLeft()
    {
        spriteRenderer.flipX = false;
        right = true;
    }
    
   
    void Dead()
    {
        rigidbody2d.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
        collider2D.enabled=false;
        Destroy(this.gameObject,1f);
        Spawner.deadEnemy = true;

    }
    public void TakeDamage(int amount)
    {
        rigidbody2d.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
        currentHealth -= amount;
        if (currentHealth <= 0)
        Dead();

    }








}
