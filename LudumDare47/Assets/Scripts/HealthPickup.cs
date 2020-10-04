using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private GameObject effectPref;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var effect = Instantiate(effectPref, transform.position, transform.rotation);
            effect.transform.parent = null;
            Destroy(effect, 6f);

            collision.GetComponent<Health>().AddHealth(1);
            Destroy(gameObject);
        }
    }
}
