using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class enemy1 : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;

//    public Vector2 direction;
    public float speed;

    public Transform hero;


    public Image health;
    public float fill;

    public float mobJumpForce;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraMove;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
//        direction.x = -1;
        speed = 0.03f;
        mobJumpForce = 10f;
        fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
 //       transform.position = Vector2.MoveTowards(transform.position, hero.position, Time.deltaTime);
        health.fillAmount = fill;

        transform.position = Vector2.MoveTowards(transform.position, hero.position, Time.deltaTime);
        anim.SetInteger("Anim", 2);

        if (fill <= 0)
        {
//            anim.SetInteger("Anim", 4);
           Destroy(gameObject);
        }

    }

    void FixedUpdate()
    {
        

//        transform.Translate(direction.normalized * speed);
        
    }

    public void TakeDamage(float damage)
    {
        fill -= damage;
    }

}
