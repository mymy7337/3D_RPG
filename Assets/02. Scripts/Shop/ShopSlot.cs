using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlot : ItemSlot
{
    public UIShop shop;
    public ItemDataSO data;

    public override void Set(ItemDataSO data)
    {
        this.data = data;
    }

    public override void Click()
    {
        shop.SelectItem(slotIndex);
    }
}
