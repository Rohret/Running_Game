using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxHeaven : MonoBehaviour
{

    public float depth = 1;
    Vector2 startPos;



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

        if (gameObject.transform.position.x < -75)
        {
            pos.x = 120f;
        }
        transform.position = pos;
    }
}
