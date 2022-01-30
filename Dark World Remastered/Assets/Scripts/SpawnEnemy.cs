using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Rigidbody enemy;
    public Rigidbody enemy2;
    public Transform spawnPoint;

    private int spawnTime;
    private bool stop;

    private bool increaseDifficulty = false;
    private float difficultyTime = 120f;
    private GameUI uiScript;


    void Start()
    {
        spawnTime = Random.Range(3, 5);
        uiScript = GameObject.FindObjectOfType<GameUI>();

        StartCoroutine(SpawnToLocation());        
    }


    IEnumerator SpawnToLocation()
    {
        while (!stop)
        {
            if (increaseDifficulty)
            {
                yield return new WaitForSeconds(spawnTime);
                Instantiate(enemy2, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                yield return new WaitForSeconds(spawnTime);
                Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            }
            
        }
        
    }

    void Update()
    {
        if(uiScript.t >= difficultyTime)
        {
            increaseDifficulty = true;
        }
    }

}
