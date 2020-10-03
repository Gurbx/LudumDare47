using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool targetMouse;
    [SerializeField] private bool targetPlayer;
    [SerializeField] private Transform target;
    [SerializeField] private Transform shootOrigin;
    
    private Vector2 shootingDirection;

    public bool IsFacingRight { get; private set; }

    public void Shoot()
    {
        weapon.Shoot(shootOrigin, transform.rotation);
    }

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

        spriteRenderer.sprite = weapon.WeaponSprite;
    }

    private void Update()
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
