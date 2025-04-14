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

    private void Start()
    {
    }

    public virtual void UseItem()
    {
        Debug.Log("ItemUsed" + Name);
    }
}
