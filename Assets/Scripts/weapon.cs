using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject specialBulletPrefab;
    public Text SpecialBullet;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public int shoots;
    bool enableShooting = false;
    

    void Start()
    {
        shoots = 0;
        SpecialBullet.text = ": " + shoots.ToString();
    }
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
            SetSpecialBulletValue();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("Shoot");
    }
    void secondShoot()
    {
        Instantiate(specialBulletPrefab,firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("Shoot");
    }
    public void Shooting()
    {
        enableShooting = true;
        shoots = 5;
        SetSpecialBulletValue();
    }

    void SetSpecialBulletValue()
    {
        SpecialBullet.text = ": " + shoots.ToString();
    }
}
