using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float jumpForcce = 400f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private UnityEvent OnLandEvent;
    [SerializeField] private float verticalRayLength = 0.55f;
    [SerializeField] private float horizontalRayLength = 0.55f;
    //[SerializeField] private Vector2 wallCheckSize;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool hasAirControl;
    [Range(0, .3f)] [SerializeField] private float movmentSmoothing = .05f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float jumpTimer;

    public bool IsFacingRight { get; private set; }
    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        IsFacingRight = true;

        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    private void FixedUpdate()
    {
        bool wasGrounded = IsGrounded;
        IsGrounded = false;

        for (int i = -1; i < 2; i++)
        {
            var pos = transform.position;
            pos.x += horizontalRayLength * 0.9f * i;
            var hit = Physics2D.Raycast(pos, Vector2.down, verticalRayLength, groundLayer);
            if (hit.collider != null)
            {
                // bounce.SetTrigger("bounce");
                IsGrounded = true;
                OnLandEvent.Invoke();
                break;
            }
        }

        //var hit = Physics2D.Raycast(transform.position, Vector2.down, verticalRayLength, groundLayer);
        //if (hit.collider != null)
        //{
        //    // bounce.SetTrigger("bounce");
        //    IsGrounded = true;
        //    OnLandEvent.Invoke();
        //}

        //animator.SetBool("grounded", IsGrounded);
    }

    public void Move(float move, bool jump)
    {
        if (IsGrounded || hasAirControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, rigidBody.velocity.y);

            if (IsDirectionBlocked())
            {
                targetVelocity.x = 0;
            }

            rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, movmentSmoothing);

            if (move > 0 && !IsFacingRight)
            {
                Flip();
            }
            else if (move < 0 && IsFacingRight)
            {
                Flip();
            }
        }
        if (IsGrounded && jump && jumpTimer <= 0)
        {
            //  bounce.SetTrigger("bounce");
            jumpTimer = 0.1f;
            IsGrounded = false;

            // (Prevent super jump)
            Vector3 vel = rigidBody.velocity;
            vel.y = 0;
            rigidBody.velocity = vel;

            rigidBody.AddForce(new Vector2(0f, jumpForcce));

            // jumpSound.pitch = Random.Range(1.1f, 1.5f);
            // jumpSound.Play();
        }

        //animator.SetBool("isIdle", !(isGrounded && Mathf.Abs(move) > 0));
    }

    private bool IsDirectionBlocked()
    {
        for (int i = -1; i < 2; i++)
        {
            var pos = transform.position;
            pos.y += verticalRayLength * 0.8f * i;
            var hit = IsFacingRight ? Physics2D.Raycast(pos, Vector2.right, horizontalRayLength, groundLayer)
                        : Physics2D.Raycast(pos, Vector2.left, horizontalRayLength, groundLayer);

            if (hit.collider != null)
            {
                return true;
            }
        }
        return false;
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        spriteRenderer.flipX = IsFacingRight;
    }

    private void Update()
    {
        jumpTimer -= Time.deltaTime;
    }
}
