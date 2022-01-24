using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTrigger : MonoBehaviour
{
    public GameObject[] spawnPointsToTrigger;

    public float timer = 8.0f;

    public bool isTriggering = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTriggering = true;        
        }
    }

    private void Update()
    {
        if (isTriggering)
        {
            foreach(var spawn in spawnPointsToTrigger)
            {
                spawn.GetComponent<Spawnpoint>().StartInvokingSpawn(timer);
            }
        }
    }
}
