using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
 

    }
     void Spawn()
 {
     var newEnemy = GameObject.Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
 }

}
