using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGreater : MonoBehaviour
{
    public Rigidbody greaterDemon;
    public Transform spawnPoint;

    private int spawnTime;
    private bool stop;


    void Start()
    {
        spawnTime = Random.Range(30, 50);

        StartCoroutine(SpawnToLocation());        
    }


    IEnumerator SpawnToLocation()
    {
        while (!stop)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(greaterDemon, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
}
