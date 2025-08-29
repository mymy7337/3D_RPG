using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerStatHandler;

public interface IDamagable
{
    public void TakeDamage(float amount);
}

public class PlayerStatHandler : MonoBehaviour, IDamagable
{
    public PlayerSO data;
    public UIConditions uiConditions;
    public PlayerStat playerStat;

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
        if (!File.Exists(Application.persistentDataPath + "/PlayerStat.json"))
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
            SaveStat();
        }
        LoadStat();
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

    public void SaveStat()
    {
        playerStat.level = level;
        playerStat.maxHp = maxHp;
        playerStat.maxMp = maxMp;
        playerStat.speed = speed;
        playerStat.attackDamage = attackDamage;
        playerStat.attackDelay = attackDelay;

        playerStat.gold = gold;
        playerStat.jewel = jewel;

        var saveStat = JsonUtility.ToJson(playerStat);
        File.WriteAllText(Application.persistentDataPath + "/PlayerStat.json", saveStat);
    }

    public void LoadStat()
    {
        var loadStat = File.ReadAllText(Application.persistentDataPath + "/PlayerStat.json");
        playerStat = JsonUtility.FromJson<PlayerStat>(loadStat);

        level = playerStat.level;
        maxHp = playerStat.maxHp;
        maxMp = playerStat.maxMp;
        speed = playerStat.speed;
        attackDamage= playerStat.attackDamage;
        attackDelay = playerStat.attackDelay;
        gold = playerStat.gold;
        jewel = playerStat.jewel;
    }

    [Serializable]
    public class PlayerStat
    {
        public int level;
        public float maxHp;
        public float maxMp;
        public float speed;
        public float attackDamage;
        public float attackDelay;

        public int gold;
        public int jewel;
    }
}
