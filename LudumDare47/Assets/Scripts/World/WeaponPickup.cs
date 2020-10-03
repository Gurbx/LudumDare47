using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private WeaponSO weaponSO;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = weaponSO.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().GetWeapon().SetWeapon(weaponSO);
            Destroy(gameObject);
        }
    }
}
