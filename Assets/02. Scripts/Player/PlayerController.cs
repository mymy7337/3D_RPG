using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshPath path;
    private PlayerStateMachine stateMachine;
    private float attackDelay = 1.5f;
    private bool isAttacking;

    [SerializeField] private GameObject Target;

    private float distance;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = PlayerManager.Instance.Player.stateMachine;
    }
    void Start()
    {
        path = new NavMeshPath();
        
    }

    void Update()
    {
        distance = Vector3.Distance(Target.transform.position, transform.position);

        if (agent.CalculatePath(Target.transform.position, path) && distance >= 1f)
        {
            stateMachine.ChangeState(stateMachine.RunState);
            agent.SetDestination(Target.transform.position);
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
