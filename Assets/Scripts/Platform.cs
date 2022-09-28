using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PlayerMovement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        
    }

    
    private void FixedUpdate()
    {
        float realVelocity = player.velocity.x / 3;
        Vector2 pos = transform.position;


        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x < -18)
        {
            pos.x = 38;
        }

        transform.position = pos;
    }
}
