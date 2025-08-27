using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    public bool IsBattle {  get; set; }

    public PlayerRunState RunState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        RunState = new PlayerRunState(this);
        AttackState = new PlayerAttackState(this);
    }

}
