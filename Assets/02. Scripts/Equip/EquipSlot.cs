using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot : ItemSlot
{
    [SerializeField] private UIEquip equip;

    public override void Set(ItemInstance item)
    {
        itemData = new ItemInstance(item);
        icon.sprite = item.icon;
    }

    public override void Click()
    {
        equip.SelectItem(slotIndex);
    }
}
