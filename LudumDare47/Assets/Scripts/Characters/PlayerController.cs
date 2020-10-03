using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController charController;
    [SerializeField] private WeaponHandler weaponHandler;
    [SerializeField] private float movmentSpeed;

    private bool shouldJump = false;
    private float horizontalMove;

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
    }

    private void FixedUpdate()
    {
        charController.Move(horizontalMove, shouldJump);
        shouldJump = false;
    }
}
