using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask jumpLayer;
    private bool jumped = false;
    public float acceleration = 10;
    public float maxAcceleartion = 10;
   
    public Vector2 velocity;
    public float maxVelocity = 100;
    public float distance = 0;
    public float maxJumpTime = 2;
    public bool holdingJump = false;
    public float holdingJumpTimer = 0;
    private Animator animator;
    public float gravityScale = 0;
    [SerializeField] GameObject m_LandingDust;
    private bool dustFlag = false;
    private BoxCollider2D boxCollider;
    Health health;
    GameManager gamemanager;
    static public bool shoes = false;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       rb.gravityScale = gravityScale;
       boxCollider = GetComponent<BoxCollider2D>();
       health = gameObject.GetComponent<Health>();
       gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
       animator.SetBool("Shoes", shoes);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded())
        {
            jumped = true;
            holdingJump = true;
            dustFlag = true;
            



        }

        if (Input.GetMouseButtonUp(0))
        {
            
            holdingJump = false;
            SetGravityToStandad();
            
        }
    }



    private void FixedUpdate()
    {
        if(velocity.x < 15)
        {
            animator.SetTrigger("SlowSpeed");
        }
        else
        {
            animator.SetTrigger("FastSpeed");
        }


        animator.SetBool("Grounded", isGrounded());
        rb.SetRotation(0);
        if (jumped && isGrounded())
        {
            rb.velocity = Vector2.up * jumpHeight;
            jumped=false;
           
            animator.SetTrigger("Jumped");
        }

        if (!isGrounded())
        {
            if (holdingJump) 
            {
                rb.gravityScale = 0;
                holdingJumpTimer += Time.fixedDeltaTime;
                if (holdingJumpTimer >= maxJumpTime)
                {
                    SetGravityToStandad();
                    holdingJump = false;
                }
            }
            else
            {
                SetGravityToStandad();
            }

        }
        else
        {
            jumped = false;
            holdingJumpTimer = 0;
        }

        //if (grounded)
        //{
            //animator.SetTrigger("Landing");
            float velocityRatio = velocity.x / maxVelocity;
            acceleration = maxAcceleartion * (1 - velocityRatio);


            velocity.x += acceleration * Time.fixedDeltaTime;

            if(velocity.x >= maxVelocity)
            {
                velocity.x = maxVelocity;
            }
        //}

        distance += (velocity.x * Time.fixedDeltaTime)/5;
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {

            if (dustFlag)
            {
                ActivateDust();
                dustFlag = false;
            }
            
            
        }
    }

    public void SetGravityToStandad()
    {
        
        rb.gravityScale = gravityScale;
    }

    private void ActivateDust()
    {
        GameObject dust = Instantiate(m_LandingDust);
        dust.transform.position = transform.position;
        Destroy(dust,0.05f);
    }

    public void ObstacleHit()
    {
        animator.SetTrigger("Dammaged");
        if (health.numOfHearts >= 2)
        {
           health.numOfHearts -= 1;
        }
        else
        {
            health.numOfHearts -= 1;
            gamemanager.GameOver();
        }
        
        if (velocity.x >= 30)
        {
            velocity.x = velocity.x - 30;

        }
        else
        {
            velocity.x = 0;
        }
        

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f,jumpLayer);
        return raycastHit.collider != null;
    }


}
