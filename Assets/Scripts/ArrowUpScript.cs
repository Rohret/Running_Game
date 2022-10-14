using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowUpScript : MonoBehaviour
{
    PlayerMovement player;
    spawnSkyUp spawner;
    ActivateArrowKeyUI actarrow;
    
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        spawner = GameObject.Find("ToSkyArrowSpawner").GetComponent<spawnSkyUp>();
        actarrow = GameObject.Find("ActivateArrowKeyUI").GetComponent<ActivateArrowKeyUI>();

    }


    private void FixedUpdate()
    {

        float realVelocity = player.velocity.x / 10;

        Vector2 pos = transform.position;


        pos.x -= realVelocity * Time.fixedDeltaTime;

        transform.position = pos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            actarrow.activeUpKeey();
            player.arrowUpCoinActivated = true;
            spawner.firstToken = false;
            Destroy(gameObject);
        }
    }
}
