using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // Assures it has a Character controller on G.O
public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform cameraTransform;

    private CharacterController controller;
    private StateTracker state;
    private Animator animator;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        state = GetComponent<StateTracker>();
        animator = GetComponent<Animator>();
    }

    public void Move(Vector2 input)
    {
        if (state.IsBusy) return;

        Vector3 moveDir = new Vector3(input.x, 0, input.y);

        if (moveDir.magnitude > 0.1f)
        {
            state.SetState(EntityState.Moving);

            Vector3 camForward = cameraTransform.forward;
            camForward.y = 0;
            camForward.Normalize();

            Vector3 camRight = cameraTransform.right;
            camRight.y = 0;
            camRight.Normalize();

            Vector3 finalDir = camForward * moveDir.z + camRight * moveDir.x;

            controller.Move(finalDir * moveSpeed * Time.deltaTime);
            transform.forward = finalDir;

            float targetSpeed = moveDir.magnitude > 0.1f ? 1f : 0f;
            //Bug to zero out the speed when the player stops moving to update the movement animation with the idle
            animator.SetFloat("Speed", targetSpeed, 0.1f, Time.deltaTime);
        }
        else
        {
            state.SetState(EntityState.Idle);
        }
    }
}