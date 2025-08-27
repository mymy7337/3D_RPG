using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
    }

    protected void StartAnimation(int animationHash)
    {
        //stateMachine.Enemy.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        //stateMachine.Enemy.Animator.SetBool(animationHash, false);
    }
}
