using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScripts : MonoBehaviour
{
    GameManager gamemanager;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            gamemanager.GameOver();
        }

    }
}
