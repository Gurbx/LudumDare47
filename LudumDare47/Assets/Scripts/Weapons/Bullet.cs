using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;

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

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        
    }
}
