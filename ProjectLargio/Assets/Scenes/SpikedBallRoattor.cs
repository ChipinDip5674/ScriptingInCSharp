using UnityEngine;

public class SpikedBallRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the object around its Z-axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}