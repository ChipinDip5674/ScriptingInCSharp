using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothness of the camera's movement
    public float verticalFollowFactor = 0.5f; // How much the camera follows the player's vertical movement (0 = no follow, 1 = full follow)
    private Vector3 offset; // Offset between the player and camera

    void Start()
    {
        // Calculate the initial offset between the player and the camera
        if (player != null)
        {
            offset = transform.position - player.position;
        }
        else
        {
            Debug.LogError("Player transform is not assigned!");
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Calculate the target position for the camera
        float targetY = Mathf.Lerp(transform.position.y, player.position.y + offset.y, verticalFollowFactor);
        Vector3 targetPosition = new Vector3(player.position.x + offset.x, targetY, transform.position.z);

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}