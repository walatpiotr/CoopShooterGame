using System.Collections.Generic;
using UnityEngine;

public class spawnTrigger : MonoBehaviour
{
    public List<GameObject> spawnPointsToTrigger;

    public float timer = 8.0f;

    public bool isTriggering = false;
    public bool exited = false;

    private void Start()
    {
        spawnPointsToTrigger = new List<GameObject>();

        var spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
        foreach (var spawn in spawnPoints)
        {
            if(Vector2.Distance(transform.position, spawn.transform.position) <= 35f)
            {
                spawnPointsToTrigger.Add(spawn);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            foreach (var spawn in spawnPointsToTrigger)
            {
                spawn.GetComponent<Spawnpoint>().StartInvokingSpawn(timer);
            }
        }
    }
}
