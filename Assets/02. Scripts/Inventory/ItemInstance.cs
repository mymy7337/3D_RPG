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
    public float priceGold;
    public int count;
    public Sprite icon;
    public int enforce;

    [Header("Type")]
    public ItemType type;

    public ItemInstance(ItemInstance item)
    {
        id = item.id;
        itemName = item.itemName;
        description = item.description;
        value = item.value;
        priceGold = item.priceGold;
        icon = item.icon;
        type = item.type;
        enforce = item.enforce;
    }

    public ItemInstance(ItemDataSO data)
    {
        id = data.id;
        itemName = data.itemName;
        description = data.description;
        value = data.value;
        priceGold = data.priceGold;
        icon = data.icon;
        type = data.type;
    }
}
