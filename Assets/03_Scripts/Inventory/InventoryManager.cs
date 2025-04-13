using System;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public Item[] startItems;

    public int maxStackedItems = 4;
    public InventorySlot[] inventorySlots; // Transform it into a dictinary. Better option to apply search later.
    public GameObject inventoryItemPrefab;


    int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
        foreach(var item in startItems)
        {
            AddItem(item);
        }
        
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if(isNumber && number > 0 && number < 9)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }


    void ChangeSelectedSlot(int newValue)
    {
        if(selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }
    public bool AddItem(Item item)
    {
        Debug.Log(inventorySlots.Length.ToString());
        // Needs an improvement. Maybe by binary search 
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < 4 && itemInSlot.item.stackable)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        // Test only, should be deleted.

        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public Item GetSelectedItem(bool use)
    {
        // This should trigger an event of using item from the player itself
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if(itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use)
                itemInSlot.count--;
            if(itemInSlot.count <= 0)
            {
                Destroy(itemInSlot.gameObject);
            }
            else
            {
                itemInSlot.RefreshCount();
            }
                return item;
        }
        return null;

    }
}
