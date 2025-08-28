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

    private bool isAttacking;

    private float distance;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        chasingTarget = GetComponent<ChasingTarget>();
    }
    void Start()
    {
        stateMachine = PlayerManager.Instance.Player.stateMachine;

        path = new NavMeshPath();
        agent.speed = PlayerManager.Instance.Player.statHandler.speed;
    }

    void Update()
    {
        if (chasingTarget.curTarget != null)
        {
            distance = Vector3.Distance(chasingTarget.curTarget.position, transform.position);

            if (agent.CalculatePath(chasingTarget.curTarget.position, path) && distance >= 2f)
            {
                stateMachine.ChangeState(stateMachine.RunState);
                agent.SetDestination(chasingTarget.curTarget.position);
            }

            if (agent.remainingDistance < 2f && !isAttacking)
            {
                agent.SetDestination(transform.position);
                StartCoroutine(Attack());
            }
        }
    }

    public void ChangeSpeed(float speed)
    {
        PlayerManager.Instance.Player.statHandler.speed = speed;
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        stateMachine.ChangeState(stateMachine.AttackState);
        PlayerManager.Instance.Player.Weapon.enabled = true;
        yield return new WaitForSeconds(PlayerManager.Instance.Player.statHandler.attackDelay);
        isAttacking = false;
        PlayerManager.Instance.Player.Weapon.enabled = false;
    }
}
