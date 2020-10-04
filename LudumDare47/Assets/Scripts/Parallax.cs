using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float scrollSpeed;

    private float yOffset;
    private Vector3 pos = Vector3.zero;

    private void Awake()
    {
        yOffset = transform.position.y;
    }

    void Update()
    {
        pos.x = playerTransform.position.x * scrollSpeed;
        pos.y = transform.position.y * 0.05f + yOffset;

        transform.position = pos;
    }
}
