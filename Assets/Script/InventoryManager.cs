using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] Slots;
    public GameObject inventoryItemPrefab;
    public void AddItem(Item item)
    {
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
