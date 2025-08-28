using System;
using UnityEngine;

[Serializable]
public class ItemInstance
{
    [Header("Info")]
    public string itemName;
    public string description;
    public float value;
    public float price;
    public int count;
    public Sprite icon;
    public bool Equip;

    [Header("Type")]
    public ItemType type;

    public ItemInstance(ItemDataSO data)
    {
        itemName = data.itemName;
        description = data.description;
        value = data.value;
        price = data.price;
        icon = data.icon;
        type = data.type;
    }
}
