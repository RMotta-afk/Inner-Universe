using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolBarController : MonoBehaviour
{
    public GameObject toolbarHud;
    public GameObject inventorySlotPreFab;

    public int slotCount = 10;

    private ItemDictionary itemDictionary;

    private Key[] hotKeys;

    private void Awake()
    {
        itemDictionary = FindFirstObjectByType<ItemDictionary>();

        hotKeys = new Key[slotCount];
        for(int i = 0; i < slotCount; i++)
        {
            hotKeys[i] = i < 9 ? (Key)((int)Key.Digit1 + i) : Key.Digit0;
        }
    }
    private void Update()
    {
        for(int i = 0; i < slotCount; i++)
        {
            if (Keyboard.current[hotKeys[i]].wasPressedThisFrame)
            {
                UseItemInSlot(i);
            }
        }
    }

    private void UseItemInSlot(int index)
    {
        Slot slot = toolbarHud.transform.GetChild(index).GetComponent<Slot>();
        if(slot.currentItem != null)
        {
            Item item = slot.currentItem.GetComponent<Item>();
            item.UseItem();
            
        }
    }

    public List<InventorySaveData> GetToolBarItems()
    {
        List<InventorySaveData> invData = new List<InventorySaveData>();

        foreach (Transform slotTransform in toolbarHud.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot.currentItem != null)
            {
                Item item = slot.currentItem.GetComponent<Item>();
                invData.Add(new InventorySaveData { itemID = item.ID, slotIndex = slotTransform.GetSiblingIndex() });
            }
        }
        return invData;
    }

    public void SetToolBarItems(List<InventorySaveData> invData)
    {
        foreach (Transform child in toolbarHud.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < slotCount; i++)
        {
            Instantiate(inventorySlotPreFab, toolbarHud.transform);
        }
        foreach (InventorySaveData data in invData)
        {
            if (data.slotIndex < slotCount)
            {
                Slot slot = toolbarHud.transform.GetChild(data.slotIndex).GetComponent<Slot>();
                GameObject itemPrefab = itemDictionary.GetItemPrefab(data.itemID);
                if (itemPrefab != null)
                {
                    GameObject item = Instantiate(itemPrefab, slot.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    slot.currentItem = item;
                }
            }
        }
    }
}
