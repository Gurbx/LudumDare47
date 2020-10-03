using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private float teleportTargetX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerGameObject = collision.gameObject;

            var pos = playerGameObject.transform.position;
            pos.x = teleportTargetX;
            playerGameObject.transform.position = pos;

            var camPos = Camera.main.transform.position;
            camPos.x = teleportTargetX;
            Camera.main.transform.position = camPos;
        }
    }
}
