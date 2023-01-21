using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] public float speed = 10f;
    [SerializeField] public float lifeTime = 5f;
    [SerializeField] public Vector3 direction;


    private float movementSpeed = 0;
    private float lifeStartTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lifeStartTime > lifeTime)
        {
            Destroy(gameObject);
        }
        movementSpeed += speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        transform.position += direction * movementSpeed;
        movementSpeed = 0;
    }
}
