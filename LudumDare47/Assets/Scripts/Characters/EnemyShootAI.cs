using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAI : MonoBehaviour
{
    private const float CHEK_COOLDOWN = 0.1f;

    [SerializeField] private WeaponHandler weaponHandler;
    [SerializeField] private float shootCooldown;
    [SerializeField] private float shootCooldonwVariation;
    [SerializeField] private float viewRange;
    [SerializeField] private LayerMask lineOfSightLayerMask;

    private bool isPlayerVisible;
    private GameObject player;
    private float checkPlayerTimer;
    private float shootCooldownTimer;
    private Vector2 playerDirection;

    private bool shouldShoot;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        if (isPlayerVisible)
        {
            Debug.DrawRay(transform.position, playerDirection.normalized * viewRange, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, playerDirection.normalized * viewRange, Color.red);
        }

        UpdateLineOfSightToPlayer();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (shouldShoot)
        {
            weaponHandler.Shoot();
            shouldShoot = false;
        }

        shootCooldownTimer -= Time.deltaTime;
        if (shootCooldownTimer > 0)
        {
            return;
        }

        weaponHandler.ShouldAim = isPlayerVisible;
        if (!isPlayerVisible)
        {
            return;
        }

        shootCooldownTimer = shootCooldown + Random.Range(-shootCooldonwVariation, shootCooldonwVariation);

        shouldShoot = true;
    }

    private void UpdateLineOfSightToPlayer()
    {
        checkPlayerTimer -= Time.deltaTime;
        if (checkPlayerTimer > 0)
        {
            return;
        }

        checkPlayerTimer = CHEK_COOLDOWN;

        isPlayerVisible = false;
        playerDirection = player.transform.position - transform.position;

        var hit = Physics2D.Raycast(transform.position, playerDirection.normalized, viewRange, lineOfSightLayerMask);

        if (hit.collider != null)
        {
            if (hit.collider.tag.Equals("Player"))
            {
                isPlayerVisible = true;
            }
        }
    }
}
