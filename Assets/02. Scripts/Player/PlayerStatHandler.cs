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
    public int level;
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
        level = 1;
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
        uiConditions.HpChange(hp, maxHp);
    }

    public void GetExt(float amount)
    { 
        exp += amount;
        uiConditions.ExpChange(exp, maxExp);
    }

    public void GetGold(int amount) 
    { 
        gold += amount;
        uiConditions.GoldChange(gold);
    }

    public void GetJewel(int amount) 
    { 
        jewel += amount;
        uiConditions.JewelChange(jewel);
    }

    public void UseGold(int amount)
    {
        gold -= amount;
        uiConditions.GoldChange(gold);
    }

    public void UseJewel(int amount) 
    { 
        jewel -= amount;
        uiConditions.JewelChange(jewel);
    }
}
