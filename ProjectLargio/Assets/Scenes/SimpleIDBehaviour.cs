using UnityEngine;

public class SimpleIDBehaviour : MonoBehaviour
{
    // Reference to the ID ScriptableObject
    public ScriptableObject id;

    private void Start()
    {
        if (id == null)
        {
            Debug.LogWarning($"{gameObject.name} is missing an ID assignment.");
        }
    }
}