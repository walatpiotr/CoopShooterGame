using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour

{
private Vector2 blowDirection;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            collision.gameObject.GetComponent<HealthBar>().TakeDamage((float)1.0);
            Vector2 dir = collision.contacts[0].point - GetComponent<Rigidbody2D>().position;
            blowDirection = -dir.normalized;
            GetComponent<Rigidbody2D>().AddForce(blowDirection * 10000f);
        }
}
}
