using System;
using UnityEngine;

public static class PlayerEvents
{
    public static event Action<Vector2> OnPlayerMovement;
    public static event Action OnPlayerStop;
    public static event Action OnPlayerJump;
    public static event Action<IWorldLivingObject> OnEntityKilled;

    public static void TriggerPlayerMovement(Vector2 moveDirection) => OnPlayerMovement?.Invoke(moveDirection);

    public static void TriggerPlayerJump() => OnPlayerJump?.Invoke();

    public static void TriggerPlayerStopMovement() => OnPlayerStop?.Invoke();
}
