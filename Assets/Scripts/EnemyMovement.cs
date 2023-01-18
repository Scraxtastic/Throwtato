using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float playerX = 2f;
    float playerY = 2f;
    float moveSpeed = 1f;
    //playerX/Y Variablen sind Platzhalter


    void Update()
    {
        float xMovement = (playerX - transform.position.x) * Time.deltaTime * moveSpeed;
        float yMovement = (playerY - transform.position.y) * Time.deltaTime * moveSpeed;
        transform.Translate(xMovement,yMovement,0);
    }
}
