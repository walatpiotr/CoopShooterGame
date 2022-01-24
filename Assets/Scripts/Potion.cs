using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float points;

    void OnCollisionEnter2D(Collision2D collision)
    {


        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            collision.gameObject.GetComponent<HealthBar>().TakeDamage(-points);
        }


    }
}