using UnityEngine;

[CreateAssetMenu(fileName = "Expendable", menuName = "Item/Expendable")]
public class ExpendableItemSO : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public float value;
    public float price;
    public Sprite icon;
}
