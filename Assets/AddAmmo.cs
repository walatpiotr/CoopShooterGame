using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmo : MonoBehaviour
{
    public string ammoType;

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Shooting>().AddAmmo(ammoType, 1);
        }


    }
}
