using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    // Player location
    [SerializeField] private Transform m_playerTransform;
    
    void LateUpdate()
    {
        // Checks if the player's location is valid
        if (m_playerTransform)
        {
            // Moves the camera to the location of the player
            transform.position = new Vector3(m_playerTransform.position.x, m_playerTransform.position.y, transform.position.z);
        }
    }
}
