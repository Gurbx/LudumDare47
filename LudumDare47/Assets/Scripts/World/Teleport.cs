using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private float teleportTargetX;
    [SerializeField] private Transform teleportSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerGameObject = collision.gameObject;

            //var pos = playerGameObject.transform.position;
            //pos.x = teleportTargetX;
            //playerGameObject.transform.position = pos;

            playerGameObject.transform.position = teleportSpawn.position;

            var camPos = Camera.main.transform.position;
            //camPos.x = teleportTargetX;
            //camPos.y += te
            //Camera.main.transform.position = camPos;

            LevelHandler.Instance.IncrementLoop();
        }
    }
}
