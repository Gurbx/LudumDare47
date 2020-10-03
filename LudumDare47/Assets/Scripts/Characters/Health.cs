using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent deathEvent;
    [SerializeField] private UnityEvent hitEvent;

    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float hitEffectLifetime;
    [SerializeField] private float deathEffectLifetime;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = _maxHealth;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        HitEffect();

        if (hitEvent != null)
        {
            hitEvent.Invoke();
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DeathEffect();
            if (deathEvent != null)
            {
                deathEvent.Invoke();
            }
            Destroy(gameObject);
        }
    }

    private void HitEffect()
    {
        if (hitEffect == null)
        {
            return;
        }
        var effect = Instantiate(hitEffect, transform.position, transform.rotation);
        effect.transform.parent = null;
        Destroy(effect, hitEffectLifetime);
    }

    private void DeathEffect()
    {
        if (deathEffect == null)
        {
            return;
        }
        var effect = Instantiate(deathEffect, transform.position, transform.rotation);
        effect.transform.parent = null;
        Destroy(effect, deathEffectLifetime);
    }

}
