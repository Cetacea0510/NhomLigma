using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BraceletSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            Item.ItemType itemtype = draggableItem.item.itemType;
            if (itemtype == Item.ItemType.Bracelet)
            {
                draggableItem.parentAfterDrag = transform;
            }
            //bool isHelmet = draggableItem.item.isHelmet == true;
            //if (ishelmet == true) //cach 1
            //{
            //    draggableItem.parentAfterDrag = transform;
            //}
        }
    }
}
