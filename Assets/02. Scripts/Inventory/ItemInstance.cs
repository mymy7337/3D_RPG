using System;
using UnityEngine;
using static UnityEditor.Progress;

[Serializable]
public class ItemInstance
{
    [Header("Info")]
    public int id;
    public string itemName;
    public string description;
    public float value;
    public float price;
    public int count;
    public Sprite icon;
    public bool Equip;

    [Header("Type")]
    public ItemType type;

    public ItemInstance(ItemInstance item)
    {
        id = item.id;
        itemName = item.itemName;
        description = item.description;
        value = item.value;
        price = item.price;
        icon = item.icon;
        type = item.type;
    }

    public ItemInstance(ItemDataSO data)
    {
        id = data.id;
        itemName = data.itemName;
        description = data.description;
        value = data.value;
        price = data.price;
        icon = data.icon;
        type = data.type;
    }
}
