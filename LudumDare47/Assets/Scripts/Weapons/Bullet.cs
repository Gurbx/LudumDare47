using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private ParticleSystem trail;
    [SerializeField] private GameObject hitEffectPrefab;

    public int Damage { get; set; }

    public void SetSpeed(float speed)
    {
        rigidbody.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(Damage);
        }
        if (trail != null)
        {
            trail.transform.parent = null;
            trail.Stop();
            Destroy(trail.gameObject, 6f);
        }

        var hitEffect = Instantiate(hitEffectPrefab, transform.position, transform.rotation);
        hitEffect.transform.parent = null;
        Destroy(hitEffect, 2f);

        CameraHandler.ScreenShake(0.1f, 0.05f, 1f);

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        
    }
}
