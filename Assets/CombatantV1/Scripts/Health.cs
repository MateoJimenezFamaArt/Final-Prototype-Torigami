using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public bool IsDead { get; private set; }

    float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (IsDead) return;

        currentHealth -= damage;

        Debug.Log($"{gameObject.name} HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            IsDead = true;
            GetComponent<StateTracker>().SetState(EntityState.Dead);
            Debug.Log($"{gameObject.name} DIED");
        }
    }


}