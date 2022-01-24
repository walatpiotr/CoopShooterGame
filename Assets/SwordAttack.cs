using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public Vector3 startingPosition;

    public float damage = 150f;

    private float timer = 0f;
    private bool isAttacking = false;

    private BoxCollider2D collider;
    private SpriteRenderer sprite;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;

        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;

        startingPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isAttacking)
        {
            timer = 0.2f;
            isAttacking = true;
            collider.enabled = true;
            sprite.enabled = true;

        }
        if (timer > 0f)
        {
            Attack();
            timer -= Time.deltaTime;
        }
        if (timer < 0f)
        {
            MoveBack();
            isAttacking = false;
        }

    }

    void Attack()
    {
        float step = 5f * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x + 0.7f, transform.localPosition.y, 0f), step);
    }

    void MoveBack()
    {
        collider.enabled = false;
        sprite.enabled = false;
        transform.localPosition = startingPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<HealthBar>().TakeDamage(damage);
        }
        if(collision.gameObject.tag == "obstacle")
        {
            collision.gameObject.GetComponent<HealthBar>().TakeDamage(damage);
        }
    }
}
