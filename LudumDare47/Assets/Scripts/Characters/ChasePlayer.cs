using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private const float CHEK_COOLDOWN = 0.1f;

    //[SerializeField] private WeaponHandler weaponHandler;
    //[SerializeField] private float shootCooldown;
    //[SerializeField] private float shootCooldonwVariation;
    [SerializeField] private float viewRange;
    [SerializeField] private LayerMask lineOfSightLayerMask;
    [SerializeField] private Rigidbody2D rbod;
    [SerializeField] private float speed;
 
    private bool isPlayerVisible;
    private GameObject player;
    private float checkPlayerTimer;
    private float shootCooldownTimer;
    private Vector2 playerDirection;

    private bool shouldMove;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        //if (isPlayerVisible)
        //{
        //    Debug.DrawRay(transform.position, playerDirection.normalized * viewRange, Color.green);
        //}
        //else
        //{
        //    Debug.DrawRay(transform.position, playerDirection.normalized * viewRange, Color.red);
        //}

        UpdateLineOfSightToPlayer();
        if (isPlayerVisible)
        {
            shouldMove = true;
        }
        else
        {
            shouldMove = false;
        }
        //HandleShooting();
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        if (shouldMove)
        {
            var direction = player.transform.position - transform.position;
            rbod.velocity = direction.normalized * speed;
        }
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
