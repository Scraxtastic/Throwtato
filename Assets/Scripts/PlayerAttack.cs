using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public float bulletSpeed = 1f;
    [SerializeField] public float bulletLifeTime = 5f;
    [Header("Attack")]
    [SerializeField] public float attackSpeed = 100;
    [SerializeField] public PlayerAim playerAim;



    private float lastBulletTime = 0;

    private void Update()
    {
        if (Time.time < lastBulletTime + 100 / attackSpeed)
        {
            return;
        }
        lastBulletTime = Time.time;
        GameObject bulletObject = Instantiate(bulletPrefab);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.speed = bulletSpeed;
        bullet.lifeTime = bulletLifeTime;
        bullet.direction = playerAim.aimDirection;
        bullet.transform.SetPositionAndRotation(transform.position, playerAim.aimRotation);
    }
}

