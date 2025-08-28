using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamagable
{
    public void TakeDamage(float amount);
}

public class PlayerStatHandler : MonoBehaviour, IDamagable
{
    public PlayerSO data;
    public UIConditions uiConditions;

    [Header("Stats")]
    public int level = 1;
    public float maxHp;
    public float maxMp;
    public float hp;
    public float mp;
    public float maxExp;
    public float exp = 0;
    public float speed;

    [Header("Property")]
    public int gold = 0;
    public int jewel = 0;

    [Header("AttackInfo")]
    public float attackDamage;
    public float attackDelay;

    private void Awake()
    {
        maxHp = data.MaxHP;
        maxMp = data.MaxMP;
        hp = maxHp;
        mp = maxMp;
        speed = data.Speed;
        maxExp = level * level * 50;
        attackDamage = data.AttackDamage;
        attackDelay = data.AttackDelay;
        uiConditions.HpChange(hp, maxHp);
        uiConditions.MpChange(mp, maxMp);
        uiConditions.ExpChange(exp, maxExp);
        uiConditions.LevelChange(level);
        uiConditions.GoldChange(gold);
        uiConditions.JewelChange(jewel);
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        Debug.Log($"플레이어{hp}");
    }

    public void GetExt(float amount) => exp += amount;

    public void GetGold(int amount) => gold += amount;

    public void GetJewel(int amount) => jewel += amount;

    public void UseGold(int amount) => gold -= amount;

    public void UseJewel(int amount) => jewel -= amount;

}
