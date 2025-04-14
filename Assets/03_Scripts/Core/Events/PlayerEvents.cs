using System;
using UnityEngine;

public static class PlayerEvents
{
    public static event Action<Vector2> OnPlayerMovement;
    public static event Action OnPlayerStop;
    public static event Action OnPlayerJump;
    public static event Action<IWorldLivingObject> OnEntityKilled;

    public static event Action <int> OnPlayerAttacked;
    public static event Action OnPLayerKilled;
    public static event Action<int> OnPlayerHeal;

    public static event Action OnStopAfterDeath;

    public static event Action<int> OnPlayerHealUp;

    public static event Action<string> OnPlayerAttack;
    public static void TriggerPlayerMovement(Vector2 moveDirection) => OnPlayerMovement?.Invoke(moveDirection);

    public static void TriggerPlayerJump() => OnPlayerJump?.Invoke();

    public static void TriggerPlayerStopMovement() => OnPlayerStop?.Invoke();

    public static void TriggerPlayerAttacked(int damage) => OnPlayerAttacked?.Invoke(damage);

    public static void TriggerPlayerDeath() => OnPLayerKilled?.Invoke();

    public static void TriggerPlayerHeal(int healAmount) => OnPlayerHeal?.Invoke(healAmount);

    public static void TriggerPlayerLevelUpHealth(int healthAmount) => OnPlayerHealUp?.Invoke(healthAmount);

    public static void TriggerPlayerAttack(string trigger) => OnPlayerAttack?.Invoke(trigger);

    public static void TriggerPlayerStopAfterDeath() => OnStopAfterDeath?.Invoke();



}
