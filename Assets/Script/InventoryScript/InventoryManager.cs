using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int MaxStackedItems = 50; 
    public InventorySlot[] Slots;
    public GameObject inventoryItemPrefab;
    public void AddItem(Item item)
    {
        //check if any slot of the same item can be stackable and has count lower than max
        for (int i = 0; i < Slots.Length; i++)
        {
            InventorySlot slot = Slots[i];
            DraggableItem itemSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemSlot != null && itemSlot.item == item && itemSlot.count < MaxStackedItems && itemSlot.item.stackable == true)
            {
                itemSlot.count++;
                itemSlot.RefreshCount();
                return;
            }
        }

        //find empty slots for items
        for (int i = 0; i < Slots.Length; i++)
        {
            InventorySlot slot = Slots[i];
            DraggableItem itemSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemSlot == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    public void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DraggableItem draggableItem = newItemGo.GetComponent<DraggableItem>();
        draggableItem.InitialiseItem(item);
    }
}
