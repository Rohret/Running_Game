using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    PlayerMovement player;
    public Transform firePoint;
    public GameObject laserprefab;
    public float laserForce = 20f;
    private bool oneRotation = false;
    public Rigidbody2D rb;
    private Rigidbody2D Playerrb;
    public float speed = 1;

    [SerializeField] private float maxTime;
    [SerializeField] private float timer = 0;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        Playerrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        float realVelocity = player.velocity.x / 10;
        Vector2 pos = transform.position;


        pos.x -= realVelocity * Time.fixedDeltaTime * speed;
        transform.position = pos;

        Shoot();

    }


    void Shoot()
    {
        Vector2 lookDir = Playerrb.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 180f;
        
        //transform.rotation = Quaternion.Euler(0, 180, 0);
        if (rb.rotation > 90 && !oneRotation)
        {
            //Uncomment to be able to rotate
            //transform.localRotation = Quaternion.Euler(-180,0,0);
            oneRotation = true;
        }
        if (rb.position.x > -5)
        {
            rb.rotation = angle;
            if (timer > maxTime)
            {
                GameObject laser = Instantiate(laserprefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb1 = laser.GetComponent<Rigidbody2D>();
                rb1.AddForce(firePoint.up * laserForce, ForceMode2D.Impulse);
                Destroy(laser,3);
                timer = 0;
            }

            timer += Time.deltaTime;
        }
        else
        {
            speed = 3;
        }


    }
}
