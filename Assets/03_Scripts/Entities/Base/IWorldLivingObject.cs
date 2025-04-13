using UnityEngine;

public interface IWorldLivingObject
{
    float MoveSpeed { get; }
    int Health { get; }
    void TakeDamage(int amount);
    void Die();
}
