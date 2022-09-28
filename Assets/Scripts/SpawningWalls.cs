using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningWalls : MonoBehaviour
{

    [SerializeField] private float maxTime;
    [SerializeField] private float timer = 0;
    [SerializeField] private float height;
    public GameObject Walls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newWalls = Instantiate(Walls);
            newWalls.transform.position = transform.position + new Vector3(0, Random.Range(0, height), 0);
            Destroy(newWalls, 10);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
