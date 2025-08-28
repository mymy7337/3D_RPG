using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatHandler : MonoBehaviour, IDamagable
{
    public EnemySO data;

    [Header("Stats")]
    public float maxHp;
    public float hp;
    public float speed;

    [Header("Reward")]
    public float exp;
    public int gold;
    public int jewel;

    [Header("AttackInfo")]
    public float attackDamage;
    public float attackDelay;

    private void Awake()
    {
        maxHp = data.MaxHP;
        hp = maxHp;
        speed = data.Speed;
        attackDamage = data.AttackDamage;
        attackDelay = data.AttackDelay;
    }

    public void TakeDamage(float amount)
    {
        if (hp == 0) return;

        hp = Mathf.Max(hp - amount, 0);
        if(hp == 0)
        {
            Die();
        }

        Debug.Log(hp);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
