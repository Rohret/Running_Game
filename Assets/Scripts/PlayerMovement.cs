using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
    public Animator animator;
    public float gravityScale = 0;
    [SerializeField] GameObject m_LandingDust;
    private bool dustFlag = false;
    private BoxCollider2D boxCollider;
    Health health;
    GameManager gamemanager;
    TriggerHeaven triggerHeaven;
    StoneScript stone1;
    StoneScript stone2;
    StoneScript stone3;
    [SerializeField] GameObject StoneObject1;
    [SerializeField] GameObject StoneObject2;
    [SerializeField] GameObject StoneObject3;
    static public bool shoes = false;
    public bool startFlying = false;
    public bool onFloor = false;
    public GameObject cam1;
    public GameObject cam2;
    [SerializeField] CinemachineVirtualCamera groundCam;
    [SerializeField] CinemachineVirtualCamera transferCam;
    [SerializeField] private AudioSource coinAudioSource;
    public float jumpToHeavenTimer = 0;
    [SerializeField] private float jumpToHeavenMaxTimer = 5;
    public bool jumpedToHeaven = false;
    public float rotz = 0;
    [SerializeField] private float rotationSpeed;
    public bool startToUseAirMovement = false;
    public float StartGroundDistance;
    public float GroundDistance;
    public bool sgrounddist = false;
    public bool onTheWayDown = false;
    public float onTheWayDownTimer = 0;
    public bool allowWallsToSpawn = true;
    public bool allowEnemySpawn = false;


    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       rb.gravityScale = gravityScale;
       boxCollider = GetComponent<BoxCollider2D>();
       health = gameObject.GetComponent<Health>();
       gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
       animator.SetBool("Shoes", shoes);
       stone1 = StoneObject1.GetComponent<StoneScript>();
       stone2 = StoneObject2.GetComponent<StoneScript>();
       stone3 = StoneObject3.GetComponent<StoneScript>();
       coinScript.numberOfCoins = 0;
       triggerHeaven = GameObject.Find("TriggerHeaven").GetComponent<TriggerHeaven>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onTheWayDown && onTheWayDownTimer < 1)
        {
            velocity.x = 0;
            onTheWayDownTimer += Time.deltaTime;
            stone1.stoneSpeed = 3f;
            stone2.stoneSpeed = 3f;
            stone3.stoneSpeed = 3f;

        }
        if (onTheWayDownTimer > 1)
        {
            onTheWayDown = false;
            allowWallsToSpawn = true;
            onTheWayDownTimer = 0;
            triggerHeaven.happenOnlyOnce = true;
        }
        if (!sgrounddist)
        {
            StartGroundDistance = distance;
            sgrounddist = true;
        }
        if (!startFlying)
        {
            GroundDistance = distance - StartGroundDistance;
        }

        if (GroundDistance > 100 && onFloor)
        {
            if (!startFlying)
            {
                StartToFly();
                startFlying = true;
                allowWallsToSpawn = false;
                allowEnemySpawn = true;
                //GroundDistance = 0;

            }
            if (jumpToHeavenTimer> jumpToHeavenMaxTimer && !jumpedToHeaven)
            {
                rb.velocity = Vector2.up * jumpHeight * 1.5f;
                jumpedToHeaven = true;
                
            }
            if(jumpToHeavenTimer < 10) { jumpToHeavenTimer += Time.deltaTime; }
            

            if (rotz > -90 && jumpToHeavenTimer > 3.5f)
            {
                rotz += -Time.deltaTime * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, 0, rotz);
            }


            stone1.stoneSpeed = 0f;
            stone2.stoneSpeed = 0f;
            stone3.stoneSpeed = 0f;
            if(jumpToHeavenTimer < 5)
            {
                velocity.x = 0;
            }
            
        }
        if (Input.GetMouseButtonDown(0) && isGrounded() && !startFlying)
        {
            jumped = true;
            holdingJump = true;
            dustFlag = true;
            onFloor = false;



        }

        if (Input.GetMouseButtonUp(0) && !startFlying)
        {
            
            holdingJump = false;
            SetGravityToStandad();
            
        }
        if (isGrounded())
        {
           
        }

        
    }



    private void FixedUpdate()
    {
        if(velocity.x < 15)
        {
            
            animator.SetTrigger("SlowSpeed");
            animator.SetBool("EnoughSpeed", false);
        }
        else
        {
           
            animator.SetBool("EnoughSpeed", true);
            animator.SetTrigger("FastSpeed");
        }


        animator.SetBool("Grounded", isGrounded());
        //rb.SetRotation(0);
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
            onFloor = true;
            if (dustFlag)
            {
                ActivateDust();
                dustFlag = false;
            }
            
            
        }
    }

    public void SetGravityToStandad()
    {
        if (!startFlying)
        {
            rb.gravityScale = gravityScale;
        }
        
    }

    private void ActivateDust()
    {
        GameObject dust = Instantiate(m_LandingDust);
        dust.transform.position = transform.position;
        Destroy(dust,0.05f);
    }

    public void ObstacleHit()
    {
        if (!startFlying)
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

    }

    private bool isGrounded()
    {
        
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.5f,jumpLayer);
        return raycastHit.collider != null;
       
    }

    private void StartToFly()
    {
        groundCam.Priority = 1;
        transferCam.Priority = 2;
        rb.freezeRotation = false;
        rb.gravityScale = 0;
        animator.SetBool("Flying", true);
        animator.SetTrigger("StartToFly");
        
        
    }

    public void playCoinSound()
    {
        coinAudioSource.Play();
    }



}
