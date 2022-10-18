using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeavenCoins : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private float timer = 0;
    [SerializeField] private float height;
    PlayerMovement player;
    public GameObject coins;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newCoins = Instantiate(coins);
            newCoins.transform.position = transform.position + new Vector3(16, Random.Range(48.8f-height, 48.8f+height), 0);
            Destroy(newCoins, 10);
            timer = 0;
        }
        if (!player.allowWallsToSpawn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

    }
}
