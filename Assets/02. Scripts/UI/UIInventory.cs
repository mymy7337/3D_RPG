using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject useBtn;
    [SerializeField] private GameObject equipBtn;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDes;
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private TextMeshProUGUI itemCount;

    public InvenSlot[] itemSlots;

    private ItemInstance selectedItemData;
    private int selectedItemIndex;

    [SerializeField] private UIEquip equip;
    private void OnEnable()
    {
        foreach (var slot in itemSlots)
        {
            if (slot != null)
            {
                selectedItemData = slot.itemData;
                if (selectedItemData.enforce != 0)
                {
                    slot.enforce.enabled = true;
                    slot.enforce.text = "+" + selectedItemData.enforce.ToString();
                }
            }
        }
        selectedItemData = null;
    }

    public void SelectItem(int index)
    {
        Reset();
        SetDes(index);
    }

    public void ClearSlot(int index)
    {
        itemSlots[index].itemData.id = 0;
        itemSlots[index].itemData.itemName = null;
        itemSlots[index].itemData.description = null;
        itemSlots[index].itemData.icon = null;
        itemSlots[index].icon.sprite = null;
        SetDes(index);
    }

    public void SetDes(int index)
    {
        selectedItemData = itemSlots[index].itemData;
        selectedItemIndex = index;

        itemName.text = selectedItemData.itemName;
        itemDes.text = selectedItemData.description;


        if (selectedItemData.type == ItemType.Expend)
        {
            itemCountText.enabled = true;
            itemCount.enabled = true;
            itemCount.text = selectedItemData.count.ToString("D2");
            useBtn.SetActive(true);
        }
        else if (selectedItemData.id == 0)
        {
            itemName.enabled = false;
            itemDes.enabled = false;
            return;
        }
        else
        {
            equipBtn.SetActive(true);
        }

    }

    public void EquipBtn()
    {
        switch (selectedItemData.type)
        {
            case ItemType.Helmet:
                if (equip.itemSlots[0].itemData.id == 0)
                {
                    equip.itemSlots[0].Set(selectedItemData);
                    ClearSlot(selectedItemIndex);
                }
                break;
            case ItemType.Armor:
                if (equip.itemSlots[1].itemData.id == 0)
                {
                    equip.itemSlots[1].Set(selectedItemData);
                    ClearSlot(selectedItemIndex);
                }
                break;
            case ItemType.Boots:
                if (equip.itemSlots[2].itemData.id == 0)
                {
                    equip.itemSlots[2].Set(selectedItemData);
                ClearSlot(selectedItemIndex);
                }
                break;
            case ItemType.Weapon:
                if (equip.itemSlots[3].itemData.id == 0)
                {
                    equip.itemSlots[3].Set(selectedItemData);
                    ClearSlot(selectedItemIndex);
                }
                break;
        }
    }

    private void Reset()
    {
        useBtn.SetActive(false);
        equipBtn.SetActive(false);
        itemCountText.enabled = false;
        itemCount.enabled = false;
        itemName.enabled = true;
        itemDes.enabled = true;
    }
}
