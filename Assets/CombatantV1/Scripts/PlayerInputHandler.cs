using UnityEngine;

// Assures it has all required scripts on G.O
[RequireComponent(typeof(StateTracker))]
[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(CombatController))]
[RequireComponent(typeof(DodgeController))]
[RequireComponent(typeof(LockOnController))]
[RequireComponent(typeof(Health))]

public class PlayerInputHandler : MonoBehaviour
{
    MovementController movement;
    CombatController combat;
    DodgeController dodge;
    LockOnController lockOn;

    void Awake()
    {
        movement = GetComponent<MovementController>();
        combat = GetComponent<CombatController>();
        dodge = GetComponent<DodgeController>();
        lockOn = GetComponent<LockOnController>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement.Move(moveInput);

        if (Input.GetMouseButtonDown(0))
            combat.UseLightAttack();

        if (Input.GetMouseButtonDown(1))
            combat.UseHeavyAttack();

        if (Input.GetKeyDown(KeyCode.Space))
            dodge.Dodge(moveInput);

        if (Input.GetKeyDown(KeyCode.Tab))
            lockOn.ToggleLock();
    }
}