using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] protected int slotIndex;
    public Image icon;
    public ItemInstance itemData;

    public virtual void Set(ItemInstance item)
    {

    }

    public virtual void Set(ItemDataSO data)
    {
        
    }

    public virtual void Click()
    {
        
    }
}
