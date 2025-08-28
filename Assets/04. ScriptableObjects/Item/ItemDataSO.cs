using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Expend
}

[CreateAssetMenu(fileName ="Item", menuName = "New Item")]
public class ItemDataSO : ScriptableObject
{
    [Header("Info")]
    public int id;
    public string itemName;
    public string description;
    public float value;
    public float price;
    public Sprite icon;

    [Header("Type")]
    public ItemType type;
}
