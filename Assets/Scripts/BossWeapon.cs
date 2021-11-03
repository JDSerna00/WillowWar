using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public Transform shootPos;
    public GameObject bullet;
    public Transform player;
    public float range;
    public float timeBTWShots;
    private float distToPlayer;
    private bool canShoot;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {

        distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer <= range)
        {
            if(canShoot)
            {
            StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet, shootPos.position, shootPos.rotation);

        canShoot = true;
    }
}
