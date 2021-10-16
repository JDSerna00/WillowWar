using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject specialBulletPrefab;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public int shoots = 5;
    bool enableShooting = false;

    // Update is called once per frame
    void Update()
    {
         
        if (Input.GetKeyDown(KeyCode.C)&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
         if (Input.GetKeyDown(KeyCode.V)&& Time.time > nextFire && enableShooting && shoots > 0)
        {
            nextFire = Time.time + fireRate;
            secondShoot();
            shoots--;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void secondShoot()
    {
        Instantiate(specialBulletPrefab,firePoint.position, firePoint.rotation);
    }
    public void Shooting()
    {
        enableShooting = true;
        shoots = 5;
    }
}
