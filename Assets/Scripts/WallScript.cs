using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float realVelocity = player.velocity.x/3;
        Vector2 pos = transform.position;


        pos.x -= realVelocity * Time.fixedDeltaTime;
        transform.position = pos;
    }
}
