using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Attack Data")]
public class AttackData : ScriptableObject
{
    public float damage = 10f;
    public float duration = 0.5f;
    public float cooldown = 0.5f;
    public float range = 2f;
    public float radius = 0.5f;
}