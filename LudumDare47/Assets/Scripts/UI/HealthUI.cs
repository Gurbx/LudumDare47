using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private GameObject healthIconPrefab;
    [SerializeField] private Color missingHeartColor;

    void Start()
    {
        playerHealth.OnHealthChanged += UpdateHealthUI;
        UpdateHealthUI(playerHealth);
    }

    private void UpdateHealthUI(Health targetHealth)
    {
        int health = 0;
        foreach (Transform child in transform)
        {
            health++;
            var img = child.GetComponent<Image>();
            if (health > targetHealth.GetCurrentHealth())
            {
                img.color = missingHeartColor;
            }
            else
            {
                img.color = Color.white;
            }

        }

        //for (int i = 1; i <= playerHealth.GetMaxHealth(); i++)
        //{
        //    var health = Instantiate(healthIconPrefab, transform);
        //    var img = health.GetComponent<Image>();
        //    if (i > playerHealth.GetCurrentHealth())
        //    {
        //        img.color = missingHeartColor;
        //    }
        //    img.enabled = true;
        //}
    }
}
