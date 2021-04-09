using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{   
    public static bool onGround;
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "sss")
            onGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "sss")
            onGround = false; 
    }
  
}
