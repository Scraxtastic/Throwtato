using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerAim : MonoBehaviour
{
    [Header("AimLine")]
    [SerializeField] public bool drawAimLine = false;
    [SerializeField] public float aimLineThickness = .1f;

    [HideInInspector] public Vector3 aimDirection;
    [HideInInspector] public Quaternion aimRotation;

    private LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        Vector3 camMousePosition = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()).origin;
        Vector2 lookDirection = camMousePosition - transform.position;
        aimDirection = lookDirection.normalized;
        transform.rotation = Quaternion.LookRotation(transform.forward, lookDirection);
        aimRotation = transform.rotation;
        Vector3[] linePositions = { transform.position, camMousePosition };
        lineRenderer.SetPositions(linePositions);
        lineRenderer.startWidth = aimLineThickness;
        lineRenderer.endWidth = aimLineThickness;
    }
}
