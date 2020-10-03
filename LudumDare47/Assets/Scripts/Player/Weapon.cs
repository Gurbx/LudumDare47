using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool targetMouse;
    [SerializeField] private bool targetPlayer;
    [SerializeField] private Transform target;
    
    private Vector2 shootingDirection;

    public bool IsFacingRight { get; private set; }

    private void Awake()
    {
        IsFacingRight = true;
    }

    private void Start()
    {
        if (targetPlayer)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (targetMouse)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shootingDirection = mousePosition - (Vector2) transform.position;
        }
        else
        {
            shootingDirection =  target.transform.position - transform.position;
        }

        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;

        if (shootingDirection.x < -1 && IsFacingRight)
        {
            Flip();
        }
        if (shootingDirection.x > 1 && !IsFacingRight)
        {
            Flip();
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Flip()
    {
        transform.localPosition *= -1;
        spriteRenderer.flipY = IsFacingRight;
        IsFacingRight = !IsFacingRight;
    }
}
