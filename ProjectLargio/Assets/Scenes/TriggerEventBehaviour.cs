using UnityEngine;
using UnityEngine.Events;

public class TriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public int damageAmount = 1; // Amount of health to reduce
    private HealthManager healthManager; // Assume this script manages health

    private void Start()
    {
        healthManager = FindObjectOfType<HealthManager>(); // Find the health manager in the scene
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name); // Debug to confirm trigger entry
        triggerEvent.Invoke();

        if (healthManager != null)
        {
            Debug.Log("Reducing health by: " + damageAmount); // Debug to confirm health reduction amount
            healthManager.ReduceHealth(damageAmount); // Reduce health
        }
        else
        {
            Debug.LogError("HealthManager not found!"); // Debug in case HealthManager is not assigned
        }
    }
}