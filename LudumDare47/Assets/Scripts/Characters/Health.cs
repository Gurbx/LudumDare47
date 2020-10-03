using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private const int INV_LAYER = 12;

    [SerializeField] private float deathSlowdown;
    [SerializeField] private float slowFadeIn, slowFadeOut;
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent deathEvent;
    [SerializeField] private UnityEvent hitEvent;

    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float hitEffectLifetime;
    [SerializeField] private float deathEffectLifetime;
    [SerializeField] private float invTimeAfterHit;

    public delegate void HealthEventHandler(Health source);

    public event HealthEventHandler OnHealthChanged;

    private float invTimer;
    private int defaultLayer;

    private int currentHealth;

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Awake()
    {
        currentHealth = _maxHealth;
        defaultLayer = gameObject.layer;
    }

    private void Update()
    {
        if (invTimer > 0)
        {
            invTimer -= Time.deltaTime;
            if (invTimer <= 0)
            {
                gameObject.layer = defaultLayer;
            }
        }
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

        if (invTimer > 0)
        {
            invTimer = invTimeAfterHit;
            gameObject.layer = INV_LAYER;
        }

        if (OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(this);
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
