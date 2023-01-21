using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [Header("Axes to follow")]
    [SerializeField] public bool followX = true;
    [SerializeField] public bool followY = true;
    [SerializeField] public bool followZ = true;
    [Header("Object to follow")]
    [SerializeField] public Transform objectToFollow;

    void Update()
    {
        Vector3 newPosition = transform.position;
        if (followX)
        {
            newPosition.x = objectToFollow.position.x;
        }
        if (followY)
        {
            newPosition.y = objectToFollow.position.y;
        }
        if (followZ)
        {
            newPosition.z = objectToFollow.position.z;
        }
        transform.position = newPosition;
    }
}
