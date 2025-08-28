using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyController controller;
    public EnemyStatHandler statHandler;

    public EnemyStateMachine stateMachine;

    [field: SerializeField] public Weapon Weapon {  get; private set; }

    private void Awake()
    {
        controller = GetComponent<EnemyController>();
        statHandler= GetComponent<EnemyStatHandler>();
        stateMachine = new EnemyStateMachine(this);
    }
}
