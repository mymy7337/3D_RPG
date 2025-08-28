using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenSlot : ItemSlot
{
    public UIInventory inventory;

    public override void Set(ItemDataSO data)
    {
        itemData = new ItemInstance(data);
        icon.sprite = data.icon;
    }

    public override void Click()
    {
        inventory.SelectItem(slotIndex);
    }
}
