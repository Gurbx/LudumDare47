using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (xSpeed, ySpeed, zSpeed) * Time.deltaTime);
    }
}
