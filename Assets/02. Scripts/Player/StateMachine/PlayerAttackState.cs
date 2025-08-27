using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private int attackInfo;

    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        attackInfo = Random.Range(0, 2);
        PlayerManager.Instance.Player.Animator.SetInteger("AttackInfo", attackInfo);
        StartAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
    }
}
