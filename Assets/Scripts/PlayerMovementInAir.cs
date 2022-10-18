using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovementInAir : MonoBehaviour
{
    PlayerMovement PM;
    [SerializeField] private float jumpHeight;
    private Rigidbody2D rb;
    private bool jumped = false;
    private bool start = false;
    Health health;
    GameManager gamemanager;
    public float StartflyingDistance;
    public float flyingDistance;
    private bool sflydist = false;
    private bool onceFlag = true;
    [SerializeField] CinemachineVirtualCamera groundCam;
    [SerializeField] CinemachineVirtualCamera transferCam;
    [SerializeField] CinemachineVirtualCamera heavenCam;
    [SerializeField] private float VelocityTimer;
    public GameObject Walls;
    private Vector3 startPos;
    public float goingDownTimer = 0;
    private float zrotation = -90;
    private bool noPressAreAllowed = false;
    private bool activateWalls = true;

    void Start()
    {
        startPos = gameObject.transform.position;
        PM = gameObject.GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        health = gameObject.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.startToUseAirMovement)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                jumped = true;
                
                
            }
            if (!sflydist)
            {
                StartflyingDistance = PM.distance;
                sflydist = true;
            }
        }

        if(flyingDistance > 230)
        {
            PM.animator.SetTrigger("FlyTransfer");
            
        }

        if(flyingDistance > 250)
        {
            
            PM.allowSpawnOfSkyUp = true;
            PM.bugFlag = false;
            noPressAreAllowed = true;
            transferCam.Priority = 3;
            heavenCam.Priority = 1;
            groundCam.Priority = 2;
            rb.gravityScale = 1;
            PM.velocity.x = 0;
            PM.zeroVelocity = true;



            goingDownTimer += Time.deltaTime;
            if (zrotation < 0)
            {
                
                zrotation += Time.deltaTime * PM.rotationSpeed;
                transform.rotation = Quaternion.Euler(0, 0, zrotation);
            }
            if (activateWalls)
            {
                GameObject newWalls = Instantiate(Walls);
                newWalls.transform.position = new Vector3(startPos.x, startPos.y - 1, startPos.z);
                Destroy(newWalls, 10);
                GameObject newWalls1 = Instantiate(Walls);
                newWalls1.transform.position = new Vector3(startPos.x + 3, startPos.y - 1, startPos.z);
                Destroy(newWalls1, 10);
                GameObject newWalls2 = Instantiate(Walls);
                newWalls2.transform.position = new Vector3(startPos.x + 6, startPos.y - 1, startPos.z);
                Destroy(newWalls2, 10);
                activateWalls = false;

            }

            if (goingDownTimer > 2)
            {             
                //reset everything from start
                flyingDistance = 0;
                PM.animator.ResetTrigger("FlyTransfer");
                PM.velocity.x = 0;
                PM.rotz = 0;
                PM.allowEnemySpawn = false;
                PM.startToUseAirMovement = false;
                PM.startFlying = false;
                PM.sgrounddist = false;
                PM.jumpedToHeaven = false;
                PM.jumpToHeavenTimer = 0;
                sflydist = false;
                start = false;
                onceFlag = true;
                //rb.gravityScale = 15;
                //rb.velocity = Vector2.down * jumpHeight * 1.5f;
                groundCam.Priority = 3;
                transferCam.Priority = 2;
                heavenCam.Priority = 1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                ToGround();
                PM.animator.SetBool("Flying", false);
                PM.onTheWayDown = true;
                flyingDistance = 0;

                PM.animator.SetTrigger("GroundedFromSpace");
                goingDownTimer = 0;
                zrotation = -90;
                noPressAreAllowed = false;
                start = false;
                jumped = false;
                PM.zeroVelocity = false;
                PM.bugFlag = true;
                activateWalls = true;
            }

        }

    }


    private void FixedUpdate()
    {
        if (PM.startToUseAirMovement && !noPressAreAllowed)
        {
            if (jumped && !start)
            {
                rb.gravityScale = 1;
                rb.freezeRotation = true;
                start = true;
                

            }

            flyingDistance = PM.distance - StartflyingDistance;

            if(flyingDistance > 20 && onceFlag)
            {
                PM.GroundDistance = 0;
                PM.arrowUpCoinActivated = false;
                PM.allowSpawnOfSkyUp = false;
                onceFlag = false;
            }

            if (jumped)
            {
                rb.velocity = Vector2.up * jumpHeight;
                jumped = false;

            }

        }
    }


    private void OnBecameInvisible()
    {
        
        if (start && !noPressAreAllowed)
        {
            gamemanager.GameOver();
        }
    }


    public void ObstacleHitInAir()
    {

        //animator.SetTrigger("Dammaged");
        if (!noPressAreAllowed)
        {
            if (health.numOfHearts >= 2)
            {
                health.numOfHearts -= 1;
            }
            else
            {
                health.numOfHearts -= 1;
                gamemanager.GameOver();
            }
        }

    }

    public void ToGround()
    {

    }
}
