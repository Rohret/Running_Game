using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    PlayerMovement player;
    static public int numberOfCoins;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,15);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.playCoinSound();
            numberOfCoins += 1;
            gameObject.SetActive(false);
        }
    }
}
