using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private bool isShooting=false;

    private float shootingRate = 0.2f;

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isShooting = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isShooting = false;
        }
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Shoot();
                timer = shootingRate;
            }
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
