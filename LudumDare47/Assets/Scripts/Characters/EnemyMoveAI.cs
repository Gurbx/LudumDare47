using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAI : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    private void FixedUpdate()
    {
        characterController.Move(0, false, false);
    }
}
