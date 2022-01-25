using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 1.5f;

    public float distance = 75f;
    public bool playerNearby = false;
    public bool invoking = false;
    public bool playerOutOfRange = true;

    private float invokeTimer;

    void Update()
    {
        if (invokeTimer >= 0f)
        {
            invokeTimer -= Time.deltaTime;
        }
        if (invokeTimer < 0f)
        {
            CancelInvoke("Spawn");
        }
    }

    void Spawn()
    {
        var newEnemy = GameObject.Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
    
    }

    void CheckDistance()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");

        foreach (var player in players)
        {
            if(Vector3.Distance(player.transform.position, transform.position) < distance)
            {
                playerNearby = true;
            }
            else
            {
                playerNearby = false;
            }
        }
    }

    public void StartInvokingSpawn(float timer)
    {
        invokeTimer = timer;
        InvokeRepeating("Spawn", 0.01f, spawnTime);
    }
}
