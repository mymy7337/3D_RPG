using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

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

    [SerializeField] private TextMeshProUGUI jewel;

    public EquipSlot[] itemSlots;

    [SerializeField] private UIInventory inventory;

    private ItemInstance selectedItemData;
    private int selectedSlotIndex;

    private void OnEnable()
    {
        jewel.text = PlayerManager.Instance.Player.statHandler.jewel.ToString();
        foreach (var slot in itemSlots)
        {
            if(slot != null)
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

    private void OnDisable()
    {
        selectedItemData = null;
        Reset();

    }

    public void SelectItem(int index)
    {
        selectedItemData = itemSlots[index].itemData;
        selectedSlotIndex = index;

        Reset();

        if (selectedItemData.id != 0)
        {
            unEquipBtn.SetActive(true);
            enfornceBtn.SetActive(true);
            itemSlots[selectedSlotIndex].enforce.enabled = true;
            itemName.enabled = true;
            itemValueText.enabled = true;
            itemValue.enabled = true;

            

            itemName.text = selectedItemData.itemName;
            itemSlots[selectedSlotIndex].enforce.text = selectedItemData.enforce == 0 ? null : "+" + selectedItemData.enforce.ToString();
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

    public void EnforceBtn()
    {
        if (PlayerManager.Instance.Player.statHandler.jewel - selectedItemData.enforce > 0 && selectedItemData.enforce < 10)
        {
            PlayerManager.Instance.Player.statHandler.jewel -= selectedItemData.enforce;
            jewel.text = PlayerManager.Instance.Player.statHandler.jewel.ToString();

            if (Random.Range(0, 100) < 100 - selectedItemData.enforce * 10)
            {
                selectedItemData.enforce++;
                selectedItemData.value += selectedItemData.enforce;
                itemSlots[selectedSlotIndex].ChangeEnfoce($"+{selectedItemData.enforce}");
                itemValue.text = selectedItemData.value.ToString();
                PlayerManager.Instance.Player.statHandler.SaveStat();
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
        itemSlots[selectedSlotIndex].enforce.text = null;
        itemName.text = null;
        itemValueText.text = null;
        itemValue.text = null;
        itemSlots[selectedSlotIndex].enforce.enabled = false;
        itemName.enabled = false;
        itemValueText.enabled = false;
        itemValue.enabled = false;
        unEquipBtn.SetActive(false);
        enfornceBtn.SetActive(false);
    }
}
