using UnityEngine;

[CreateAssetMenu(fileName = "Knight", menuName = "Entity/Knight")]
public class PlayerSO : ScriptableObject
{
    [field: Header("Stats")]
    [field: SerializeField] public float MaxHP {  get; private set; }
    [field: SerializeField] public float MaxMP { get; private set; }

    [field: SerializeField] public float Speed { get; private set; }

    [field: Header("AttackInfo")]
    [field: SerializeField] public float AttackDamage { get; private set; }
    [field: SerializeField] public float AttackDelay { get; private set; }
    [field: SerializeField] public float Def { get; private set; }

}
