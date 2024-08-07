using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeapontSlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {            
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            string itemName = draggableItem.item.itemName;
            int itemDamage = draggableItem.item.bonusDamage;
            Item.ItemType itemtype = draggableItem.item.itemType;
            bool equipState = draggableItem.item.equipState;
            if (itemtype == Item.ItemType.Weapon)
            {
                equipState = true;
                draggableItem.parentAfterDrag = transform;
                
            }
            //if (itemName == "Fire Bow")
            //{
            //    int weaponDamage = itemDamage/*draggableItem.item.bonusDamage*/;
            //}
            //else if (itemName == "Holy Bow")
            //{
            //    int weaponDamage = itemDamage /*draggableItem.item.bonusDamage*/;
            //}
            //else
            //{
            //    return;
            //}
            //bool isWeapon = draggableItem.item.isWeapon == true;
            //if (isWeapon == true) //cach 1
            //{
            //    draggableItem.parentAfterDrag = transform;
            //}
        }
    }
}
