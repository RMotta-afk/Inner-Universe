using System;
using Assets._03_Scripts.Entities.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IItem
{
    public int ID;
    public string Name;
    public string Description;
    public TextMeshProUGUI itemName { get; set; }
    public TextMeshProUGUI ItemText { get ; set ; }

    private int _healingAmount = 30;

    public static event Action<int> OnPlayerHeal;

    private void Start()
    {
    }

    public virtual void UseItem()
    {
        if (Name.Contains("potion"))
        {
            PlayerEvents.TriggerPlayerHeal(_healingAmount);

            Destroy(gameObject);
        }
            
    }
}
