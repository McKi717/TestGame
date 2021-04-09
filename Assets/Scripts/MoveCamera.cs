using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviour
{

    public GameObject Hero;
    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float downLimit;
    [SerializeField]
    private float upLimit;

    void Update()
    {
       Vector3 posHero = new Vector3(Mathf.Clamp(Hero.transform.position.x,leftLimit,rightLimit),Mathf.Clamp(Hero.transform.position.y, downLimit, upLimit), -10f);
       Vector3 nowMove = Vector3.Lerp(gameObject.transform.position, posHero, Time.deltaTime * 1.5f) ;
       gameObject.transform.position = nowMove;           
    }
}
