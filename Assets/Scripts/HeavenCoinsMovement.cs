using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenCoinsMovement : MonoBehaviour
{
    PlayerMovement player;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();


    }


    private void FixedUpdate()
    {

        float realVelocity = player.velocity.x / 5;

        Vector2 pos = transform.position;


        pos.x -= realVelocity * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
