using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private void Start()
    {

    }
    private void Update()
    {
        Vector3 maxCamPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue(), 0);
        Vector2 direction = (maxCamPosition).normalized;
        transform.right = direction;
    }
}
