using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerHeaven : MonoBehaviour
{
    Rigidbody2D player;
    PlayerMovement pl;
    public bool happenOnlyOnce = true;
    public GameObject arrow;
    ArrowUI au;
    [SerializeField] CinemachineVirtualCamera HeavenCamera;
    //public Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        pl = player.GetComponent<PlayerMovement>();
        au = arrow.GetComponent<ArrowUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.transform.position.y > 48)
        {
            if (happenOnlyOnce)
            {
                player.velocity = Vector3.zero;
                player.angularVelocity = 0f;
                HeavenCamera.Priority = 3;
                pl.startToUseAirMovement = true;
                happenOnlyOnce = false;
                au.decitvateUIarrow();
                

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (happenOnlyOnce)
        //{
        //    player.velocity = Vector3.zero;
        //    player.angularVelocity = 0f;
        //    HeavenCamera.Priority = 3;
        //    pl.startToUseAirMovement = true;
        //    happenOnlyOnce=false;
        //    Destroy(gameObject);

        //}


    }
}
