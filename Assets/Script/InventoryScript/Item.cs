using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public ItemType itemType;
    public ActionType actionType;

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both UI")]
    public Sprite image;

    public enum ItemType
    {
        Weapon,
        Bracelet,
        Helmet,
        Necklace,
        Consumable
    }

    public enum ActionType
    {
        Equip,
        Drink
    }
}
