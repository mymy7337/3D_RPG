using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    public PlayerSO data;

    [Header("Stats")]
    public int level;
    public float maxHp;
    public float maxMp;
    public float hp;
    public float mp;
    public float exp;
    public float speed;

    [Header("Property")]
    public int gold;
    public int jewel;

    [Header("AttackInfo")]
    public float attackDamage;
    public float attackDelay;

    private void Awake()
    {
        data = GetComponent<PlayerSO>();
        maxHp = data.MaxHP;
        maxMp = data.MaxMP;
        hp = maxHp;
        mp = maxMp;
        speed = data.Speed;
        exp = level * level * 50;
        attackDamage = data.AttackDamage;
        attackDelay = data.AttackDelay;
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
    }

    public void GetExt(float amount) => exp += amount;

    public void GetGold(int amount) => gold += amount;

    public void GetJewel(int amount) => jewel += amount;

    public void UseGold(int amount) => gold -= amount;

    public void UseJewel(int amount) => jewel -= amount;

}
