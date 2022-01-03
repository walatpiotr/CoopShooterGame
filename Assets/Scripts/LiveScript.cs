using UnityEngine;

public class LiveScript : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.2f);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "enemy")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.2f);
            Destroy(gameObject);

            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(100);
        }

        if(collision.gameObject.tag == "obstacle")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.2f);
            Destroy(gameObject);

            collision.gameObject.GetComponent<ObjectHealth>().TakeDamage(100);
        }


    }
}
