using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos - playerTransform.position;
        //mouseOffsetFromPlayer = mousePos - playerTransform.position;
    }
}
