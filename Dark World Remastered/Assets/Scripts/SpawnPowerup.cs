using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerup : MonoBehaviour
{
    public Rigidbody powerUp;
    public Transform spawnPoint;

    private int spawnTime;
    private bool stop;


    void Start()
    {
        spawnTime = Random.Range(60, 120);

        StartCoroutine(SpawnToLocation());        
    }


    IEnumerator SpawnToLocation()
    {
        while (!stop)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(powerUp, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
}
