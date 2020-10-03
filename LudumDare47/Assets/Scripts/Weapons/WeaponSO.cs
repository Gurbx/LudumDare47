using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "LD47/Weapon")]
public class WeaponSO : ScriptableObject
{
    public Weapon.WeaponType type;

    public int damage = 1;
    public float spread;
    public float minSpeed;
    public float maxSpeed;
    public float shootingCooldown;
    public int minNrProjectiles = 1;
    public int maxNrProjectiles = 1;
    public Vector3 projectileScale = Vector3.one;

    public Sprite sprite;
}
