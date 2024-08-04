using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemToPickUp;

    public void PickUpItem(int id)
    {
        inventoryManager.AddItem(itemToPickUp[id]);
    }
}
