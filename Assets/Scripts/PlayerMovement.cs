using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Sqrt(1^2 + 1^2) = 1.414
    public const float diagonalFactor = 1.414f;
    public float speed = 5f;

    private PlayerControls controls;
    private PlayerControls.MovementActions movement;

    private Vector3 movementVector;

    void Awake()
    {
        controls = new PlayerControls();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float speedToAdd = speed * Time.deltaTime;
        Vector3 currentMove = new Vector3();
        if (movement.Up.IsPressed())
        {
            currentMove.y += speedToAdd;
        }
        if (movement.Down.IsPressed())
        {
            currentMove.y -= speedToAdd;
        }
        if (movement.Left.IsPressed())
        {
            currentMove.x -= speedToAdd;
        }
        if (movement.Right.IsPressed())
        {
            currentMove.x += speedToAdd;
        }
        if (currentMove.x != 0 && currentMove.y != 0)
        {
            //prevents 1.41 time speed on diagonal movement
            currentMove.x /= diagonalFactor;
            currentMove.y /= diagonalFactor;
        }
        movementVector += currentMove;
    }

    private void FixedUpdate()
    {
        transform.position += movementVector;
        movementVector = new Vector3();
    }

    private void OnEnable()
    {
        controls.Enable();
        movement = controls.Movement;
        movement.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
        movement.Disable();
    }
}
