using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIEquip : MonoBehaviour
{
    [SerializeField] private GameObject unEquipBtn;
    [SerializeField] private GameObject enfornceBtn;

    [SerializeField] private TextMeshProUGUI lv;
    [SerializeField] private TextMeshProUGUI atk;
    [SerializeField] private TextMeshProUGUI def;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemValueText;
    [SerializeField] private TextMeshProUGUI itemValue;

    public EquipSlot[] itemSlots;

    [SerializeField] private UIInventory inventory;

    private ItemInstance selectedItemData;
    private int selectedSlotIndex;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        selectedItemData = null;
        Reset();

    }

    public void SelectItem(int index)
    {
        Reset();
        selectedItemData = itemSlots[index].itemData;

        if (selectedItemData.id != 0)
        {
            unEquipBtn.SetActive(true);
            itemName.enabled = true;
            itemValueText.enabled = true;
            itemValue.enabled = true;

            selectedSlotIndex = index;

            itemName.text = selectedItemData.itemName;
            switch (selectedItemData.type)
            {
                case ItemType.Weapon:
                    itemValueText.text = "공격력";
                    break;
                case ItemType.Helmet:
                case ItemType.Armor:
                case ItemType.Boots:
                    itemValueText.text = "방어력";
                    break;
            }
            itemValue.text = selectedItemData.value.ToString();
        }
    }

    public void UnEquip()
    {
        for(int i = 0;  i < inventory.itemSlots.Length; i++)
        {
            if(FindEmptySlot(i))
            {
                inventory.itemSlots[i].Set(selectedItemData);
                itemSlots[selectedSlotIndex].itemData.id = 0;
                itemSlots[selectedSlotIndex].itemData.itemName = null;
                itemSlots[selectedSlotIndex].itemData.description = null;
                itemSlots[selectedSlotIndex].itemData.icon = null;
                itemSlots[selectedSlotIndex].icon.sprite = null;
                Reset();
                return;
            }
        }
    }

    public bool FindEmptySlot(int index)
    {
        if (inventory.itemSlots[index].itemData.id == 0)
        {
            return true;
        }

        return false;
    }

    private void Reset()
    {
        itemName.text = null;
        itemValueText.text = null;
        itemValue.text = null;
        itemName.enabled = false;
        itemValueText.enabled = false;
        itemValue.enabled = false;
        unEquipBtn.SetActive(false);
    }
}
