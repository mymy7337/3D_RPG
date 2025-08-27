using UnityEngine;

[CreateAssetMenu(fileName = "Goblin", menuName = "Entity/Goblin")]
public class EnemySO : ScriptableObject
{
    [field: Header("Stats")]
    [field: SerializeField] public float MaxHP { get; private set; }

    [field: SerializeField] public float Speed { get; private set; }

    [field: Header("AttackInfo")]
    [field: SerializeField] public float AttackDamage { get; private set; }
    [field: SerializeField] public float AttackDelay { get; private set; }

    [field: Header("Reward")]
    [field: SerializeField] public float Exp { get; private set; }
    [field: SerializeField] public int Gold { get; private set; }
    [field: SerializeField] public int Jewel {  get; private set; }

}
