using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshPath path;
    private PlayerStateMachine stateMachine;
    private ChasingTarget chasingTarget;

    private float attackDelay = 1.5f;
    private bool isAttacking;

    private float distance;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        chasingTarget = GetComponent<ChasingTarget>();
        stateMachine = PlayerManager.Instance.Player.stateMachine;
    }
    void Start()
    {
        path = new NavMeshPath();
        
    }

    void Update()
    {
        distance = Vector3.Distance(chasingTarget.curTarget.position, transform.position);

        if (agent.CalculatePath(chasingTarget.curTarget.position, path) && distance >= 1f)
        {
            stateMachine.ChangeState(stateMachine.RunState);
            agent.SetDestination(chasingTarget.curTarget.position);
        }

        if(agent.remainingDistance < 0.1f && !isAttacking)
        {
            agent.SetDestination(transform.position);
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        stateMachine.ChangeState(stateMachine.AttackState);
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }
}
