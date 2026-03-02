using UnityEngine;

public class CombatController : MonoBehaviour
{
    public AttackData lightAttack;
    public AttackData heavyAttack;

    public Hitbox hitboxLight;
    public Hitbox hitboxHeavy;

    private StateTracker state;
    private Animator animator;

    void Awake()
    {
        state = GetComponent<StateTracker>();
        animator = GetComponent<Animator>();
    }

    public void UseLightAttack()
    {
        if (state.IsBusy) return;

        state.SetState(EntityState.Attacking);
        animator.SetTrigger("LightAttack");
    }

    public void UseHeavyAttack()
    {
        if (state.IsBusy) return;

        state.SetState(EntityState.Attacking);
        animator.SetTrigger("HeavyAttack");
    }

    // CALLED BY ANIMATION EVENT
    public void ActivateHitbox_Light()
    {
        hitboxLight.Activate(lightAttack.damage);
    }

    public void ActivateHitbox_Heavy()
    {
        hitboxHeavy.Activate(heavyAttack.damage);
    }

    // CALLED BY ANIMATION EVENT
    public void DeactivateHitbox_light()
    {
        hitboxLight.Deactivate();
    }

    public void DeactivateHitbox_Heavy()
    {
        hitboxHeavy.Deactivate();
    }

    // CALLED AT END OF ANIMATION
    public void EndAttack()
    {
        state.SetState(EntityState.Idle);
    }
}