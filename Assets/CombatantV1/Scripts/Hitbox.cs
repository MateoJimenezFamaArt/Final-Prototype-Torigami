using UnityEngine;

[RequireComponent(typeof(Collider))] // Assures it has a Character controller on G.O
public class Hitbox : MonoBehaviour
{
    public float damage;
    public LayerMask targetMask;

    private bool active;
    [SerializeField] private bool debugMode = true;

    public void Activate(float dmg)
    {
        damage = dmg;
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        if (((1 << other.gameObject.layer) & targetMask) != 0)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);

                if (debugMode)
                    Debug.Log($"HIT: {other.name} took {damage} damage");
            }
        }
    }

    void OnDrawGizmos()
    {
        if (!active) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<Collider>().bounds.size);
    }


}