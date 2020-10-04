using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private float teleportTargetX;
    [SerializeField] private Transform teleportSpawn;
    [SerializeField] private GameObject visuals;

    private bool isActive;

    private void Start()
    {
        LevelHandler.Instance.CrystalCollected += OnCrystalCollected;
    }

    private void OnCrystalCollected()
    {
        isActive = true;
        visuals.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive)
        {
            return;
        }
        if (collision.CompareTag("Player"))
        {
            var playerGameObject = collision.gameObject;
            playerGameObject.transform.position = teleportSpawn.position;
            var camPos = Camera.main.transform.position;
            LevelHandler.Instance.IncrementLoop();
            isActive = false;
            visuals.SetActive(false);
        }
    }
}
