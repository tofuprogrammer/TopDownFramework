using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CameraFollowsPlayer : MonoBehaviour
{
    public Transform player;
    // LateUpdate is called immediately after Update() completes.
    void LateUpdate()
    {
        if (player)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
