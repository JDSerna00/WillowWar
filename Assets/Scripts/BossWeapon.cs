using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public Transform firePos;
    public GameObject bossBulletPrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bossBulletPrefab, firePos.position, firePos.rotation);
    }
}
