using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private float maxTimeAfterFirst;
    [SerializeField] private float timer = 0;
    PlayerMovement player;
    public GameObject heartelem;
    public bool firstToken = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame

    //player.allowWallsToSpawn
    void Update()
    {
        if (firstToken)
        {
            spawnskyup(maxTime);
            
        }

        if (player.allowSpawnOfSkyUp)
        {
            firstToken = true;
        }


    }


    private void spawnskyup(float theTimer)
    {
        if (timer > theTimer)
        {
            GameObject newSkyUp = Instantiate(heartelem);
            heartelem.transform.position = transform.position + new Vector3(0, 0, 0);
            Destroy(heartelem, 20);
            timer = 0;
            firstToken = false;
        }
        if (!player.allowSpawnOfSkyUp)
        {
            timer += Time.deltaTime;
        }
        else
        {
           
            timer = 0;
        }
    }
}
