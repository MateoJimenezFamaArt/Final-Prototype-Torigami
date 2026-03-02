using UnityEngine;
using System.Collections;

public class DodgeController : MonoBehaviour
{
    public float dodgeDistance = 4f;
    public float dodgeDuration = 0.3f;

    private CharacterController controller;
    private StateTracker state;
    private Animator animator;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        state = GetComponent<StateTracker>();
        animator = GetComponent<Animator>();
    }

    public void Dodge(Vector2 input)
    {
        if (state.IsBusy) return;

        StartCoroutine(PerformDodge(input));
    }

    IEnumerator PerformDodge(Vector2 input)
    {
        animator.SetTrigger("Dodge");
        state.SetState(EntityState.Dodging);

        Vector3 dir = new Vector3(input.x, 0, input.y);

        bool isDirectional = dir.magnitude > 0.1f;

        if (isDirectional)
            dir.Normalize();

        dir.Normalize();

        float elapsed = 0f;

        while (elapsed < dodgeDuration)
        {
            if (isDirectional)
                controller.Move(dir * (dodgeDistance / dodgeDuration) * Time.deltaTime);

            elapsed += Time.deltaTime;
            yield return null;
        }

    }

    public void EndDodge() //Set it on the anim events
    {
        state.SetState(EntityState.Idle);
    }
}