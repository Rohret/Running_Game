using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{

    PlayerMovement player;
    private bool positive = true;
    public float stoneSpeed = 3f;
    public float immuneTimer;
    public bool vulnerable;
   // public GameObject platform;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        stoneSpeed = 3f;
        // platform = GameObject.Find("Ground").GetComponent<Platform>();

    }

    // Update is called once per frame
    void Update()
    {
        //print(platform.transform.position.x);
    }

    private void FixedUpdate()
    {
       
        Vector2 pos = transform.localPosition;


        

        if (pos.x >= 3)
        {
            positive = false;

        }
        else if (pos.x <= -6)
        {
            positive = true;
        }

            if (positive)
            {
                pos.x += stoneSpeed * Time.fixedDeltaTime;
            }
            else
            {
                pos.x -= stoneSpeed * Time.fixedDeltaTime;
            }

        if (immuneTimer > 3)
        {
            vulnerable = true;
        }
        else
        {
            vulnerable = false;
        }
        immuneTimer += Time.fixedDeltaTime;
        transform.localPosition = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (vulnerable)
            {
                player.ObstacleHit();
                immuneTimer = 0;

            }
        }
         
        
    }

    
}
