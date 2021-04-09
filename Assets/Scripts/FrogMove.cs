using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    [SerializeField]
    float speed = 4f;
    public Vector2 jumpHeight;
   
    SpriteRenderer spriteRenderer;
    new Rigidbody2D rigidbody2D;
    Animator animator;
    public GameObject checkGround;

    private bool faceRight;
    private void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround.onGround == true)
        {
            rigidbody2D.AddForce(jumpHeight, ForceMode2D.Impulse);
            CheckGround.onGround = false;   
        }
       
        if (CheckGround.onGround == false&&animator.GetBool("Hit")==false)
        {
            animator.SetBool("Jump", true);
        }
        else 
            animator.SetBool("Jump", false);


        if (transform.position.y < -10)
        {
            transform.position = new Vector3(-6, -2, 0);
        }
    }
    private void FixedUpdate()
    {
        float xMove = Input.GetAxis("Horizontal");
        Vector3 moveX = new Vector3(xMove, 0, 0);
        transform.position += moveX * speed * Time.deltaTime;


        if (xMove > 0 && faceRight == true)
        {
            //spriteRenderer.flipX = false;
            Flip();
        }
        if (xMove < 0&&faceRight==false)
        { 
            Flip();
        }
        
        
        if (xMove > 0||xMove<0)
        {
            animator.SetBool("RightRun", true);
        }
        if (xMove == 0)
        {
            animator.SetBool("RightRun", false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = new Vector3(-6, -2, 0);
            animator.SetTrigger("Hit");
        }
    }
 
    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);  
    }
   


} 

   
    

