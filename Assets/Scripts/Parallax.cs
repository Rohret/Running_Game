using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float depth = 1;
    Vector2 startPos;
    public GameObject follow;
    

    PlayerMovement player;
    
    void Start()
    {
       // follow = GetComponent<GameObject>();   
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        startPos = gameObject.transform.position;
       


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if(follow.transform.position.x < 0 && follow.transform.position.x > -1)
        {
            pos.x = 25.2f;
        }
        transform.position = pos;
    }
}
