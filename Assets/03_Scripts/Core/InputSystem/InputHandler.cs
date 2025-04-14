using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private void Update()
    {
        HandlePlayerMovement();
        HandlePlayerJump();
        HandlePlayerAttack();
    }

    private void HandlePlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerEvents.TriggerPlayerAttackMovement();
        }
    }

    private void HandlePlayerMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
        {
            PlayerEvents.TriggerPlayerMovement(new Vector2(moveInput, 0));
        }
        else
        {
            PlayerEvents.TriggerPlayerStopMovement();
        }
    }

    private void HandlePlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerEvents.TriggerPlayerJump();
        }
    }
}
