using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string runParameterName = "@Run";
    [SerializeField] private string battleParameterName = "Battle";

    [SerializeField] private string attackParameterName = "@Attack";

    public int IdleParameterHash { get; private set; }
    public int RunParameterHash {  get; private set; }
    public int BattleParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }

    public void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        BattleParameterHash = Animator.StringToHash(battleParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
    }
}
