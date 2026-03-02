using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    [SerializeField] private GameObject visual;

    private void Start()
    {
        if (visual == null)
        {
            Debug.LogError("Visual GameObject is not assigned in the inspector.");
        }
        else
        {
            visual.SetActive(false); // Ensure it's off by default
        }
    }

    public void ActivateReticle(bool value)
    {
        visual.SetActive(value);
    }
}