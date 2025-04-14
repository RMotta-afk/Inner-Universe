using System;
using Assets._03_Scripts.Player;
using UnityEngine;

public class HealthPotion : Item
{
    private int _healingAmount = 30;

    public static event Action<int> OnPlayerHeal;
    public override void UseItem()
    {
        OnPlayerHeal?.Invoke(_healingAmount);

        Destroy(gameObject);

    }
}
