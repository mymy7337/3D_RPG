using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    [SerializeField] private GameObject buyBtn;
    [SerializeField] private GameObject sellBtn;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDes;
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private TextMeshProUGUI itemCount;

    [SerializeField] private ShopSlot[] itemSlots;

    [SerializeField] private UIInventory inventory;

    [SerializeField] private ItemDataSO[] itemDatas;

    private void Awake()
    {
        SetSlot();
    }

    public void SetSlot()
    {
        for (int i = 0; i < itemSlots.Length && i< itemDatas.Length; i++)
        {
            itemSlots[i].Set(itemDatas[i]);
            itemSlots[i].icon.sprite = itemDatas[i].icon;
        }
    }

    public void SelectItem(int index)
    {
        var selectedItemData = itemSlots[index].data;
        itemName.text = selectedItemData.itemName;
        itemDes.text = selectedItemData.description;
        if(selectedItemData.type == ItemType.Expend)
        {
            itemCountText.enabled = true;
            itemCount.enabled = true;
            //itemCount.text = 
        }
    }

    public bool FindEmptySlot(int index)
    {
        if (inventory.itemSlots[index].itemData == null)
        {
            return true;
        }

        return false;
    }
}
