using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] protected int slotIndex;
    public Image icon;
    public ItemInstance itemData;

    public UIInventory inventory;

    public void Set(ItemDataSO data)
    {
        itemData = new ItemInstance(data);
        icon.sprite = itemData.icon;
    }

    public virtual void Click()
    {
        
    }
}
