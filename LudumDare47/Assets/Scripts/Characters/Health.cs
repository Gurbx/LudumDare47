using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float deathSlowdown;
    [SerializeField] private float slowFadeIn, slowFadeOut;
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
        CameraHandler.ScreenShake(0.2f, 0.1f, 1f);
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
        SlowMotion.SlowTime(deathSlowdown, slowFadeIn, slowFadeOut);
        CameraHandler.ScreenShake(0.7f, 0.3f, 1f);
        if (deathEffect == null)
        {
            return;
        }
        var effect = Instantiate(deathEffect, transform.position, transform.rotation);
        effect.transform.parent = null;
        Destroy(effect, deathEffectLifetime);
    }

}
