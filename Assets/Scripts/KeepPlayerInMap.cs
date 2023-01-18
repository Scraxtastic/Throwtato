using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerInMap : MonoBehaviour
{
    [SerializeField] public SpriteRenderer mapRenderer;

    private Vector2 mapSize;
    private Vector3 mapPos;
    private void Start()
    {
        Vector3 playerSize = new Vector3(transform.localScale.x, transform.localScale.y) / 2;
        mapSize = mapRenderer.bounds.size / 2 - playerSize;
        mapPos = mapRenderer.transform.position;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, mapPos.x - mapSize.x, mapPos.x + mapSize.x);
        pos.y = Mathf.Clamp(pos.y, mapPos.y - mapSize.y, mapPos.y + mapSize.y);
        transform.position = pos;
    }
}
