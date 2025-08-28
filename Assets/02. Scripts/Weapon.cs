using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    public PlayerSO data;

    private List<Collider> alreadyCollider = new List<Collider>();

    private void OnEnable()
    {
        alreadyCollider.Clear();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return;
        if (alreadyCollider.Contains(other)) return;

        alreadyCollider.Add(other);

        if (other.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(data.AttackDamage);
        }

    }
}
