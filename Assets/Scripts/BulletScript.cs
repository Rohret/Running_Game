using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    PlayerMovementInAir player;
    public float immuneTimer1;
    public bool vulnerable1 = true;
    public GameObject HitEffect;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovementInAir>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            

                
                player.ObstacleHitInAir();
                immuneTimer1 = 0;
                GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.3f);
                Destroy(gameObject);

            
        }
        if (collision.gameObject.tag == "Shield")
        {


            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(gameObject);


        }


    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
