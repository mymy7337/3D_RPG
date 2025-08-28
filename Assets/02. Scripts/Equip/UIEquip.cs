using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    }

    public void SelectItem(int index)
    {
        unEquipBtn.SetActive(true);
        itemName.enabled = true;
        itemValueText.enabled = true;
        itemValue.enabled = true;

        selectedItemData = itemSlots[index].itemData;
        
        itemName.text = selectedItemData.itemName;
        switch(selectedItemData.type)
        {
            case ItemType.Weapon:
                itemValueText.text = "공격력";
                break;
            case ItemType.Helmet: case ItemType.Armor: case ItemType.Boots:
                itemValueText.text = "방어력";
                break;
        }
        itemValue.text = selectedItemData.value.ToString();
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
