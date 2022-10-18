using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartmovement : MonoBehaviour
{
    PlayerMovement player;
    Health health;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        health = GameObject.Find("Player").GetComponent<Health>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("hit player");
            if (health.numOfHearts < 3)
            {
                health.numOfHearts += 1;
            }
            Destroy(gameObject);
        }
    }
}
