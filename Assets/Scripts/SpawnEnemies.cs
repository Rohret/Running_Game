using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    PlayerMovement player;
    [SerializeField] private float maxTime;
    [SerializeField] private float timer = 0;
    [SerializeField] private float height;
    public GameObject Enemies;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime && player.jumpedToHeaven)
        {
            GameObject newEnemies = Instantiate(Enemies);
            newEnemies.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newEnemies, 20);
            timer = 0;
        }
        if (player.jumpedToHeaven && player.allowEnemySpawn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
        
    }
}
