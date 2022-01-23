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
    public float reloadTime;

    public int currentMagazine;

    private float reloadTimer = 0f;
    private bool isReloading = false;
    public GameObject reloadIndicator;

    private void Awake()
    {
        Configure("rifle");    
    }

    private void Start()
    {
        reloadIndicator = GameObject.Find("ReloadInformation");
        reloadIndicator.SetActive(false);
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

        if (currentMagazine == 0)
        {
            NeededReload();
        }

        if (isReloading)
        {
            reloadTimer -= Time.deltaTime;
        }

        if (reloadTimer < 0f)
        {
            currentMagazine = magazineSize;
            reloadIndicator.SetActive(false);
            isReloading = false;
        }

        if (!isReloading)
        {
            CheckGunSwitch();
        }
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                if (currentMagazine > 0)
                {
                    Shoot();
                    timer = fireRate;
                }
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

        currentMagazine -= 1;
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
                currentMagazine = magazineSize;
                damage = AssaultRifle.damage;
                reloadTime = AssaultRifle.reloadTime;
                Debug.Log("configured Rifle");
                break;
            case "machine":
                accuracyAngle = MachineGun.accuracyAngle;
                bulletForce = MachineGun.bulletForce;
                fireRate = MachineGun.fireRate;
                magazineSize = MachineGun.magazineSize;
                currentMagazine = magazineSize;
                damage = MachineGun.damage;
                reloadTime = MachineGun.reloadTime;
                Debug.Log("configured Machine Gun");
                break;
            case "revolver":
                accuracyAngle = Revolver.accuracyAngle;
                bulletForce = Revolver.bulletForce;
                fireRate = Revolver.fireRate;
                magazineSize = Revolver.magazineSize;
                currentMagazine = magazineSize;
                damage = Revolver.damage;
                reloadTime = Revolver.reloadTime;
                Debug.Log("configured Revolver");
                break;
            case "sniper":
                accuracyAngle = SniperRifle.accuracyAngle;
                bulletForce = SniperRifle.bulletForce;
                fireRate = SniperRifle.fireRate;
                magazineSize = SniperRifle.magazineSize;
                currentMagazine = magazineSize;
                damage = SniperRifle.damage;
                reloadTime = SniperRifle.reloadTime;
                Debug.Log("configured Sniper");
                break;
        }
    }

    private void NeededReload()
    {
        reloadIndicator.SetActive(true);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Reload()
    {
        Debug.Log("reloading!");
        SetTimer(reloadTime);
    }

    private void SetTimer(float time)
    {
        if (!isReloading)
        {
            isReloading = true;
            reloadTimer = time;
        }
    }

    private void CheckGunSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Configure("rifle");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Configure("machine");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Configure("revolver");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Configure("sniper");
        }
    }
}
