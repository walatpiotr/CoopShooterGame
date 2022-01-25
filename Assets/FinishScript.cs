using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            SceneManager.LoadScene("Finish");
            // TODO add finish canvas or something
        }               
    }
}