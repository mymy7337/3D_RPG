using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    private NavMeshAgent agent;
    private NavMeshPath path;
    private EnemyStateMachine stateMachine;
    private ChasingTarget chasingTarget;

    private bool isAttacking;

    private float distance;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        chasingTarget = GetComponent<ChasingTarget>();

        path = new NavMeshPath();
        agent.speed = enemy.statHandler.speed;
    }

    void Start()
    {
        stateMachine = enemy.stateMachine;

    }

    void Update()
    {
        distance = Vector3.Distance(chasingTarget.curTarget.position, transform.position);

        if (agent.CalculatePath(chasingTarget.curTarget.position, path) && distance >= 1f)
        {
            stateMachine.ChangeState(stateMachine.RunState);
            agent.SetDestination(chasingTarget.curTarget.position);
        }

        if (agent.remainingDistance < 0.5f && !isAttacking)
        {
            agent.SetDestination(transform.position);
            StartCoroutine(Attack());
        }
    }

    public void ChangeSpeed(float speed)
    {
        enemy.statHandler.speed = speed;
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        stateMachine.ChangeState(stateMachine.AttackState);
        yield return new WaitForSeconds(enemy.statHandler.attackDelay);
        isAttacking = false;
    }
}
