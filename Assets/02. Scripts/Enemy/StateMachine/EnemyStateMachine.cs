using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }

    public bool IsBattle { get; set; }

    public EnemyRunState RunState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }

    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;

        RunState = new EnemyRunState(this);
        AttackState = new EnemyAttackState(this);
    }

}
