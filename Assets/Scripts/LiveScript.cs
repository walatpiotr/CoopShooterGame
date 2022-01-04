using UnityEngine;

public class LiveScript : MonoBehaviour
{
    public GameObject hitEffect;
    public float dmg;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.2f);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "obstacle")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.2f);
            Destroy(gameObject);

            collision.gameObject.GetComponent<HealthBar>().TakeDamage(dmg);
        }


    }
}
