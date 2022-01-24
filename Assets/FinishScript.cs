using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FinishScript : MonoBehaviour
{

    public List<GameObject> enemies;

    void Start()
    {
        enemies = new List<GameObject>() { };
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy").ToList();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach(var enemy in enemies)
            {
                Destroy(enemy);
            }

            // TODO add finish canvas or something

        }               
    }
}