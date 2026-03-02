using UnityEngine;
using System.Linq;

public class LockOnController : MonoBehaviour
{
    public float lockRadius = 15f;
    public LayerMask enemyMask;
    private TargetIndicator currentIndicator;

    public Transform CurrentTarget { get; private set; }

    void Update()
    {
        if (CurrentTarget == null) return;

        Vector3 dir = CurrentTarget.position - transform.position;
        dir.y = 0;
        transform.forward = dir.normalized;

        if (CurrentTarget.GetComponent<Health>().IsDead)
        {
            SetTarget(null);
            FindNewTarget();
        }


    }

    public void ToggleLock()
    {
        if (CurrentTarget == null)
            FindNewTarget();
        else
            SetTarget(null);
    }

    void FindNewTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, lockRadius, enemyMask);

        Transform nearest = hits
            .OrderBy(h => Vector3.Distance(transform.position, h.transform.position))
            .First().transform;

        SetTarget(nearest);

    }

    void SetTarget(Transform newTarget)
    {
        if (CurrentTarget != null)
        {
            currentIndicator?.ActivateReticle(false);
        }

        CurrentTarget = newTarget;

        if (CurrentTarget != null)
        {
            currentIndicator = CurrentTarget.GetComponent<TargetIndicator>();
            currentIndicator?.ActivateReticle(true);
        }
    }
}