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
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI price;

    [SerializeField] private ShopSlot[] itemSlots;

    [SerializeField] private UIInventory inventory;

    [SerializeField] private ItemDataSO[] itemDatas;

    private ItemDataSO selectedItemData;

    private void OnEnable()
    {
        SetSlot();
    }

    private void OnDisable()
    {
        selectedItemData = null;
        Reset();
        
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
        selectedItemData = itemSlots[index].data;
        itemName.text = selectedItemData.itemName;
        itemDes.text = selectedItemData.description;
        priceText.enabled = true;
        price.enabled = true;
        price.text = $"{selectedItemData.price} G";
        if(selectedItemData.type == ItemType.Expend)
        {
            itemCountText.enabled = true;
            itemCount.enabled = true;
            //itemCount.text = 
        }
        else
        {
            itemCountText.enabled = false;
            itemCount.enabled = false;
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

    private void Reset()
    {
        itemName.text = null;
        itemDes.text = null;
        itemCount.text = null;
        price.text = null;
        itemCountText.enabled = false;
        itemCount.enabled = false;
        priceText.enabled = false;
        price.enabled = false;       
    }
}
