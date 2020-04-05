using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hero : MonoBehaviour
{
    
    Rigidbody2D rb;
    Animator anim;

    public float HeroGetsDamage;

    public Image health;
    public float fill;

    public float speed;
    public float jumpForce;
    public float moveInput;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumps;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        HeroGetsDamage = 0.3f;
        fill = 1f;
        speed = 5f;
        jumpForce = 5f;
        GameTime.StartTime();
    }

    void Flip() //Метод разворота героя
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        health.fillAmount = fill;
//        moveInput = Input.GetAxis("Horizontal");
//        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (isGrounded == true)
            extraJumps = 2;

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0) // при нажатии стрелки вверх, герой прыгает
        {
            Jump(); //Метод Jump
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetInteger("animNumber", 1);
            Flip();    
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetInteger("animNumber", 3);    
        }

        if (transform.position.y < -5)
            fill = 0;

        if (fill <= 0)
        {
            Invoke("ReloadLevel", 1);
            GameTime.StopTime();

        }
    }

    void Jump() // Rules of hero's jump
    {
//        rb.AddForce(transform.up * 27f, ForceMode2D.Impulse);
        rb.velocity = Vector2.up * jumpForce;
        extraJumps--;
    }

    void OnCollisionEnter2D(Collision2D Collision1)
    {
        if(Collision1.gameObject.tag == "testEnemy1")
        {
            fill -= HeroGetsDamage;
            
        }

        
    }

       void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex);
    }
}
