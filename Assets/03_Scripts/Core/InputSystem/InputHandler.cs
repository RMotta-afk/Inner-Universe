using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public bool canHandle = true;
    private void Update()
    {
        if (canHandle)
        {
            HandlePlayerMovement();
            HandlePlayerJump();
            HandleAttack();
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

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z) )
        {
            PlayerEvents.TriggerPlayerAttack("Attack1");

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerEvents.TriggerPlayerAttack("Attack2");

        }
    }

}
