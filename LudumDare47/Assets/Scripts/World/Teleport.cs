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
            playerGameObject.transform.position = teleportSpawn.position;
            var camPos = Camera.main.transform.position;
            LevelHandler.Instance.IncrementLoop();
        }
    }
}
