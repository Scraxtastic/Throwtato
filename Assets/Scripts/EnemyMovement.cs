using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// Kommentare von Nick:
    /// - Variablen bitte nach oben packen, dass die nicht zwischen Methoden liegen
    /// - GameObject.Find("Player") bitte ersetzen. Am besten im Spawner als [SerializeField] einbauen oder ggf. static Variable im Enemy Script.
    /// - beim setzen der moveDirection gibst du die deltaTime und moveSpeed mit. Beim setzen der velocity multiplizierst du nochmal mit dem moveSpeed? :D
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private Vector2 moveDirection;
    public Rigidbody2D enemy;
    float moveSpeed = 1f;
    GameObject player;
    private Vector3 playerPos;
   
   
    void Update()
    {
        player = GameObject.Find("Player");
        if(player)
        {
            playerPos = player.transform.position;
        }

        moveDirection.x = (playerPos.x - transform.position.x) * Time.deltaTime * moveSpeed;
        moveDirection.y = (playerPos.y - transform.position.y) * Time.deltaTime * moveSpeed;
        enemy.velocity = moveDirection.normalized * moveSpeed;
    }
}
