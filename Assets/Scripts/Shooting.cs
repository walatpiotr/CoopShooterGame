using UnityEngine;
using Assets.Classes;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private bool isShooting=false;
    private float timer = 0f;

    public float fireRate;
    public float bulletForce;
    public int magazineSize;
    public float accuracyAngle;
    public float damage;

    private void Awake()
    {
        Configure("rifle");    
    }

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
                timer = fireRate;
            }
        }
    }

    void Shoot()
    {
        var tiltAngle = Random.Range(-accuracyAngle, accuracyAngle);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<LiveScript>().dmg = damage;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        bullet.transform.Rotate(0f, 0f, tiltAngle);
        rb.SetRotation(Quaternion.Euler(0f, 0f, tiltAngle));

        rb.AddForce(rb.transform.up * bulletForce, ForceMode2D.Impulse);
    }

    private void Configure(string gun)
    {
        switch (gun)
        {
            case "rifle":
                accuracyAngle = AssaultRifle.accuracyAngle;
                bulletForce =  AssaultRifle.bulletForce;
                fireRate = AssaultRifle.fireRate;
                magazineSize = AssaultRifle.magazineSize;
                damage = AssaultRifle.damage;
                Debug.Log("configured Rifle");
                break;
            // TODO add new cases
        }
    }
}
