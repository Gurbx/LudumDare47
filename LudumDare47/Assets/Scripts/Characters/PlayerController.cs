using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private const int PLAYER_LAYER = 8;
    private const int INV_LAYER = 12;

    [SerializeField] private CharacterController charController;
    [SerializeField] private WeaponHandler weaponHandler;
    [SerializeField] private float movmentSpeed;
    [SerializeField] private float invTime;
    [SerializeField] private float dodgeCooldown;

    [SerializeField] private SpriteRenderer debugRendere;

    private bool shouldJump = false;
    private bool shouldDodge = false;
    private float horizontalMove;

    private float dodgeTimer;
    private float invTimer;

    public Weapon GetWeapon()
    {
        return weaponHandler.GetWeapon();
    }

    private void Start()
    {
        charController.CharacterRolled += PlayerRolled;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movmentSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            shouldJump = true;
        }

        if (Input.GetMouseButton(0))
        {
            weaponHandler.Shoot();
            CameraHandler.ScreenShake(0.1f, 0.05f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
        {
            if (dodgeTimer <= 0)
            {
                shouldDodge = true;
            }
        }

        if (invTimer > 0)
        {
            invTimer -= Time.deltaTime;
            if (invTimer <= 0)
            {
                gameObject.layer = PLAYER_LAYER;
                debugRendere.color = Color.green;
            }
        }

        if (dodgeTimer > 0)
        {
            dodgeTimer -= Time.deltaTime;
            if (dodgeTimer <= 0)
            {
                debugRendere.color = Color.white;
            }
        }
    }

    private void PlayerRolled(CharacterController charController)
    {
        gameObject.layer = INV_LAYER;
        invTimer = invTime;
        dodgeTimer = dodgeCooldown;
        debugRendere.color = Color.blue;
        SlowMotion.SlowTime(0.3f, 0.2f, 0.6f);
    }

    private void FixedUpdate()
    {
        charController.Move(horizontalMove, shouldJump, shouldDodge);
        shouldJump = false;
        shouldDodge = false;
    }
}
