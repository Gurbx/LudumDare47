using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelHandler.Instance.IncrementCrystals();
            var effect = Instantiate(effectPrefab, transform.position, transform.rotation);
            effect.transform.parent = null;
            Destroy(effect, 7f);
            Destroy(gameObject);
        }
    }
}
