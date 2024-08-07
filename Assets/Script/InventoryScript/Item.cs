using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public ItemType itemType;
    public ActionType actionType;
    public string itemName;
    public int bonusDamage;
    public int bonusHealth;

    [Header("Only UI")]
    public bool stackable = true;
    public bool equipState;
    //public bool isWeapon = true;
    //public bool isHelmet = true;
    //public bool isNecklace = true;
    //public bool isBracelet = true;


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
