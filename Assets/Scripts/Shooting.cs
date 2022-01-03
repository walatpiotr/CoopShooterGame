using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Shoot();
            Debug.Log("shoot!");
        }
    }

    void Shoot()
    {
        var tiltAngle = Random.Range(-1f, 1f);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        bullet.transform.Rotate(0f, 0f, tiltAngle);
        rb.SetRotation(Quaternion.Euler(0f, 0f, tiltAngle));

        rb.AddForce(rb.transform.up * bulletForce, ForceMode2D.Impulse);
    }
}
