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
    [SerializeField] private TextMeshProUGUI itemCount;

    [SerializeField] private ItemSlot[] itemSlots;

    public void SelectItem(int index)
    {
        useBtn.SetActive(false);
        equipBtn.SetActive(false);
        unEquipBtn.SetActive(false);

        var selectedItemData = itemSlots[index].itemData;
        itemName.text = selectedItemData.itemName;
        itemDes.text = selectedItemData.description;

        if (selectedItemData.type == ItemType.Weapon || selectedItemData.type == ItemType.Armor)
        {
            if(selectedItemData.Equip)
            {
                equipBtn.SetActive(true);
            }
            else
            {
                unEquipBtn.SetActive(true);
            }
        }
        else
        {
            useBtn.SetActive(true);
        }
    }
}
