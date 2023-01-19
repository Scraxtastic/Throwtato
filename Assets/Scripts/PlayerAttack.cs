using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerAttack : MonoBehaviour
{
    [Header("AimLine")]
    [SerializeField] public bool drawAimLine = false;
    [SerializeField] public float aimLineThickness = .1f;
    
    private LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        Vector3 camPosition = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()).origin;
        Vector2 lookDirection = camPosition - transform.position;
        transform.rotation = Quaternion.LookRotation(transform.forward, lookDirection);
        Vector3[] linePositions = { transform.position, camPosition };
        lineRenderer.SetPositions(linePositions);
        lineRenderer.startWidth = aimLineThickness;
        lineRenderer.endWidth = aimLineThickness;
    }
}
