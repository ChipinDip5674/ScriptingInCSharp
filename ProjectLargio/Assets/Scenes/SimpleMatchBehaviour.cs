using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehaviour : MonoBehaviour
{
    public ScriptableObject id; // The ID to match
    public UnityEvent matchEvent; // Event to trigger when matched

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} triggered by {other.gameObject.name}");

        SimpleIDBehaviour key = other.GetComponent<SimpleIDBehaviour>();
        if (key != null && key.id == id) // Check if the key matches the fire's ID
        {
            Debug.Log("Match found! Turning off fire.");
            matchEvent?.Invoke(); // Trigger the event to turn off the fire
        }
        else
        {
            Debug.Log("No match found or key is missing SimpleIDBehaviour.");
        }
    }
}