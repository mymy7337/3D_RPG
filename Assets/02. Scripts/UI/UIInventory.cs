using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject useBtn;
    [SerializeField] private GameObject equipBtn;
    [SerializeField] private GameObject unEquipBtn;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDes;
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private TextMeshProUGUI itemCount;

    public InvenSlot[] itemSlots;

    private ItemInstance selectedItemData;

    public void SelectItem(int index)
    {
        Reset();
        
        selectedItemData = itemSlots[index].itemData;
        itemName.text = selectedItemData.itemName;
        itemDes.text = selectedItemData.description;

        if (selectedItemData.type == ItemType.Expend)
        {
            itemCountText.enabled = true;
            itemCount.enabled = true;
            itemCount.text = selectedItemData.count.ToString("D2");
            useBtn.SetActive(true);
        }
        else if(selectedItemData.type == ItemType.Weapon ||  selectedItemData.type == ItemType.Armor)
        {
            if (selectedItemData.Equip)
            {
                equipBtn.SetActive(true);
            }
            else
            {
                unEquipBtn.SetActive(true);
            }
        }
        else if(selectedItemData.id == 0)
        {
            itemName.enabled = false;
            itemDes.enabled = false;
            return;
        }
    }

    private void Reset()
    {
        useBtn.SetActive(false);
        equipBtn.SetActive(false);
        unEquipBtn.SetActive(false);
        itemCountText.enabled = false;
        itemCount.enabled = false;
        itemName.enabled = true;
        itemDes.enabled = true;
    }
}
