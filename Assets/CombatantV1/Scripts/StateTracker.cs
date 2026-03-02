using UnityEngine;

public class StateTracker : MonoBehaviour
{

    //Works in tandem with the EntityState enum to track the current state of the combatant.
    //This is used by all other systems to determine what can be done and what cannot be done at a time.
    public EntityState CurrentState { get; private set; } = EntityState.Idle;

    public bool IsBusy => // Checks if the combatant is buisy doing either an attack, dodge or is stunned.
        CurrentState == EntityState.Attacking ||
        CurrentState == EntityState.Dodging ||
        CurrentState == EntityState.Stunned;

    public void SetState(EntityState newState) // Method to set the current state of the combatant.
    {
        CurrentState = newState;
    }
}