using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingTarget : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float detectRange = 100;
    [SerializeField] private float detectDelay = 0.3f;

    public Transform curTarget;
    private Collider[] targets = new Collider[100];

    private void Start()
    {
        StartCoroutine(SearchTarget());
    }

    private IEnumerator SearchTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(detectDelay);
        while (true)
        {
            int targetNumber = Physics.OverlapSphereNonAlloc(pivot.position, detectRange, targets, layerMask);
            float closeDistance = float.MaxValue;

            for (int i = 0; i < targetNumber; i++)
            {
                var t = targets[i];
                float distance = (t.transform.position - pivot.transform.position).sqrMagnitude;
                if (distance <= closeDistance)
                {
                    closeDistance = distance;
                    curTarget = targets[i].transform;
                }
            }
            yield return wait;
        }
    }
}
