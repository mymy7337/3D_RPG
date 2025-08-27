using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Knight", menuName = "Entity/Knight")]
public class PlayerSO : ScriptableObject
{
    [field: Header("Stats")]
    [field: SerializeField] public int MaxHP {  get; private set; }
    [field: SerializeField] public int HP { get; private set; }
    [field: SerializeField] public int MaxMP { get; private set; }
    [field: SerializeField] public int MP { get; private set; }
    [field: SerializeField] public int Exp { get; private set; }

    [field: SerializeField] public float Speed { get; private set; }

    [field:Header("Property")]
    [field: SerializeField] public int Gold { get; private set; }
    [field: SerializeField] public int Jewel { get; private set; }

    [field: Header("AttackInfo")]

    [field: SerializeField] public float AttackDelay { get; private set; }

}
