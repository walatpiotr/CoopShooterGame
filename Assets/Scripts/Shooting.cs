using UnityEngine;
using Assets.Classes;
using System;
using System.Collections.Generic;

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

    public int currentMagazine = AssaultRifle.magazineSize;

    private float reloadTimer = 0f;
    private bool isReloading = false;
    public GameObject reloadIndicator;

    public Dictionary<string, Tuple<int, int>> magazines = new Dictionary<string, Tuple<int, int>>{};

    public string currentWeapon = "rifle";

    private void Awake()
    {
        magazines.Add("rifle", new Tuple<int, int>(AssaultRifle.magazineSize, 2));
        magazines.Add("machine", new Tuple<int, int>(MachineGun.magazineSize, 3));
        magazines.Add("revolver", new Tuple<int, int>(Revolver.magazineSize, 2));
        magazines.Add("sniper", new Tuple<int, int>(SniperRifle.magazineSize, 2));

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
            SetUpMagazineState(currentWeapon);
            reloadTimer = 0f;
        }

        if (!isReloading)
        {
            CheckGunSwitch();
        }

        ConsistMagazines();
    }

    private void ConsistMagazines()
    {
        switch (currentWeapon)
        {
            case "rifle":
                magazines["rifle"] = new Tuple<int, int>(currentMagazine, magazines["rifle"].Item2);
                break;
            case "machine":
                magazines["machine"] = new Tuple<int, int>(currentMagazine, magazines["machine"].Item2);
                break;
            case "revolver":
                magazines["revolver"] = new Tuple<int, int>(currentMagazine, magazines["revolver"].Item2);
                break;
            case "sniper":
                magazines["sniper"] = new Tuple<int, int>(currentMagazine, magazines["sniper"].Item2);
                break;
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

    private void SetUpMagazineState(string gun)
    {
        switch (gun)
        {
            case "rifle":
                magazines["rifle"] = new Tuple<int, int>(AssaultRifle.magazineSize, magazines["rifle"].Item2 - 1);
                break;
            case "machine":
                magazines["machine"] = new Tuple<int, int>(MachineGun.magazineSize, magazines["machine"].Item2 - 1);
                break;
            case "revolver":
                magazines["revolver"] = new Tuple<int, int>(Revolver.magazineSize, magazines["revolver"].Item2 - 1);
                break;
            case "sniper":
                magazines["sniper"] = new Tuple<int, int>(SniperRifle.magazineSize, magazines["sniper"].Item2 - 1);
                break;
        }
    }

    bool CheckIfHasMagazine(string gun)
    {
        switch (gun)
        {
            case "rifle":
                if (magazines["rifle"].Item2 > 0)
                {
                    return true;
                }

                return false;
            case "machine":
                if (magazines["machine"].Item2 > 0)
                {
                    return true;
                }

                return false;
            case "revolver":
                if (magazines["revolver"].Item2 > 0)
                {
                    return true;
                }

                return false;
            case "sniper":
                if (magazines["sniper"].Item2 > 0)
                {
                    return true;
                }

                return false;
        }

        return false;
    }

    void Shoot()
    {
        var tiltAngle = UnityEngine.Random.Range(-accuracyAngle, accuracyAngle);

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
                currentMagazine = magazines["rifle"].Item1;
                damage = AssaultRifle.damage;
                reloadTime = AssaultRifle.reloadTime;
                currentWeapon = "rifle";
                Debug.Log("configured Rifle");
                break;
            case "machine":
                accuracyAngle = MachineGun.accuracyAngle;
                bulletForce = MachineGun.bulletForce;
                fireRate = MachineGun.fireRate;
                magazineSize = MachineGun.magazineSize;
                currentMagazine = magazines["machine"].Item1;
                damage = MachineGun.damage;
                reloadTime = MachineGun.reloadTime;
                currentWeapon = "machine";
                Debug.Log("configured Machine Gun");
                break;
            case "revolver":
                accuracyAngle = Revolver.accuracyAngle;
                bulletForce = Revolver.bulletForce;
                fireRate = Revolver.fireRate;
                magazineSize = Revolver.magazineSize;
                currentMagazine = magazines["revolver"].Item1;
                damage = Revolver.damage;
                reloadTime = Revolver.reloadTime;
                currentWeapon = "revolver";
                Debug.Log("configured Revolver");
                break;
            case "sniper":
                accuracyAngle = SniperRifle.accuracyAngle;
                bulletForce = SniperRifle.bulletForce;
                fireRate = SniperRifle.fireRate;
                magazineSize = SniperRifle.magazineSize;
                currentMagazine = magazines["sniper"].Item1;
                damage = SniperRifle.damage;
                reloadTime = SniperRifle.reloadTime;
                currentWeapon = "sniper";
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
        if (CheckIfHasMagazine(currentWeapon))
        {
            Debug.Log("reloading!");
            SetTimer(reloadTime);
        }
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

    public void AddAmmo(string ammoType, int amount)
    {
        switch (ammoType)
        {
            case "rifle":
                magazines["rifle"] = new Tuple<int, int>(magazines["rifle"].Item1, magazines["rifle"].Item2 + 1);
                break;
            case "machine":
                magazines["machine"] = new Tuple<int, int>(magazines["machine"].Item1, magazines["machine"].Item2 + 1);
                break;
            case "revolver":
                magazines["revolver"] = new Tuple<int, int>(magazines["revolver"].Item1, magazines["revolver"].Item2 + 1);
                break;
            case "sniper":
                magazines["sniper"] = new Tuple<int, int>(magazines["sniper"].Item1, magazines["sniper"].Item2 + 1);
                break;
        }
    }
}
