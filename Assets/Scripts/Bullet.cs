using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] public float speed = 10f;
    [SerializeField] public float lifeTime = 5f;
    [SerializeField] public Vector3 direction;
    [SerializeField] public string layerNameToAttack = "Enemy";

    private float movementSpeed = 0;
    private float lifeStartTime;
    void Start()
    {
        lifeStartTime = Time.time;
    }

    void Update()
    {
        if (Time.time - lifeStartTime > lifeTime)
        {
            Destroy(gameObject);
        }
        movementSpeed += speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 1));
    }

    void FixedUpdate()
    {
        transform.position += direction * movementSpeed;
        movementSpeed = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerNameToAttack))
        {
            // TODO Give Enemy health?
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
