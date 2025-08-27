using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    NavMeshPath path;
    [SerializeField] private GameObject Target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        path = new NavMeshPath();
        
    }

    void Update()
    {
        if (agent.CalculatePath(Target.transform.position, path))
        {
            agent.SetDestination(Target.transform.position);
        }
    }
}
