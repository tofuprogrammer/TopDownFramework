using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border") || collision.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            if (collision.CompareTag("Asteroid"))
            {
                Destroy(collision.gameObject);
                TopDownCharacterController.playerScore += 200;
            }
        }
    }
}
