using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerController controller;

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Animator { get; private set; }

    public PlayerStateMachine stateMachine;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        AnimationData.Initialize();
        controller = GetComponent<PlayerController>();
        Animator = GetComponentInChildren<Animator>();
        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
    }
}
