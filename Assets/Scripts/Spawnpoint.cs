using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 3.0f;

    public float distance = 75f;
    public bool playerNearby = false;
    public bool invoking = false;
    public bool playerOutOfRange = true;

    void Update()
    {
        CheckDistance();
    }

    private void FixedUpdate()
    {
        if (playerNearby && !invoking)
        {
            InvokeRepeating("Spawn", 0.1f, spawnTime);
            invoking = true;
            // playerNearby = false;
        }
        if (!playerNearby && invoking)
        {
            CancelInvoke("Spawn");
            invoking = false;
            // playerNearby = false;
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
}
