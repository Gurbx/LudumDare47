using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet playerBullet;
    [SerializeField] private Bullet enemyBullet;

    [SerializeField] protected bool isPlayerWeapon;
    [SerializeField] WeaponSO weaponSO;

    //protected float spread;
    //protected int damage;
    //protected float minSpeed;
    //protected float maxSpeed;
    //protected float shootingCooldown;

    private WeaponType type;

    private float cooldownTimer;

    public Sprite WeaponSprite { get; private set; }

    public void Shoot(Transform spawnTransform, Quaternion weaponRotation)
    {
        if (cooldownTimer > 0)
        {
            return;
        }
        cooldownTimer = weaponSO.shootingCooldown;

        switch (type)
        {
            case WeaponType.BULLET:
                {
                    ShootBullet(spawnTransform, weaponRotation);
                    break;
                }
            default:
                ShootBullet(spawnTransform, weaponRotation);
                break;

        }
    }

    #region Shoot Bullet
    private void ShootBullet(Transform spawnTransform, Quaternion weaponRotation)
    {
        int nrBullets = Random.Range(weaponSO.minNrProjectiles, weaponSO.maxNrProjectiles);

        for (int i = 0; i < nrBullets; i++)
        {
            float rotationOffset = Random.Range(-weaponSO.spread, weaponSO.spread);
            Quaternion rotation = weaponRotation;
            rotation = rotation * Quaternion.Euler(0, 0, rotationOffset);

            var bullet = SpawnBullet(spawnTransform.position, rotation);
            bullet.Damage = weaponSO.damage;

            float bulletSpeed = Random.Range(weaponSO.minSpeed, weaponSO.maxSpeed);
            bullet.SetSpeed(bulletSpeed);

            bullet.transform.localScale = weaponSO.projectileScale;

            Destroy(bullet, 10f);
        }
    }

    private Bullet SpawnBullet(Vector2 position, Quaternion rotation)
    {
        if (isPlayerWeapon)
        {
            var bullet = Instantiate(playerBullet, position, rotation);
            return bullet.GetComponent<Bullet>();
        }
        else
        {
            var bullet = Instantiate(enemyBullet, position, rotation);
            return bullet.GetComponent<Bullet>();
        }
    }
    #endregion



    private void Awake()
    {
        WeaponSprite = weaponSO.sprite;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            cooldownTimer = 0;
        }
    }

    public enum WeaponType
    {
        BULLET,
    }
}
