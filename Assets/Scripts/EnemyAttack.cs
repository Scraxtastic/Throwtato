using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
    public GameObject enemy;
    private GameObject player;
    public float shotTiming;
    private float shotCounter;
    private Vector3 playerPos;
    private Vector3 enemyPos;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = shotTiming;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            playerPos = player.transform.position;
            enemyPos = enemy.transform.position;
        }

        //firePoint zeigt auf Spieler
        Vector2 offset = new Vector2(playerPos.x - enemyPos.x, playerPos.y - enemyPos.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);


        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0 )
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            shotCounter = shotTiming;
        }
    }
}
