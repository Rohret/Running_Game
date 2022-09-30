using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterAdWall : MonoBehaviour
{
    public GameObject Walls;
    public GameObject Player;
    // Start is called before the first frame update
    
    public void spawnWallAfterAd()
    {
        GameObject newWalls = Instantiate(Walls);
        newWalls.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y-1, Player.transform.position.z);
        Destroy(newWalls, 10);
        GameObject newWalls1 = Instantiate(Walls);
        newWalls1.transform.position = new Vector3(Player.transform.position.x+3, Player.transform.position.y - 1, Player.transform.position.z);
        Destroy(newWalls1, 10);
        GameObject newWalls2 = Instantiate(Walls);
        newWalls2.transform.position = new Vector3(Player.transform.position.x + 6, Player.transform.position.y - 1, Player.transform.position.z);
        Destroy(newWalls2, 10);
    }
}
