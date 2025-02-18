using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    // Reference to scoring system script
    // Allows calling its public functions
    public ScoreSystem m_scoreSystem;

    void Start()
    {
        // Gets scoring system
        m_scoreSystem = FindFirstObjectByType<ScoreSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks tag of object collided with
        // Called if colliding with border or asteroid
        if (collision.CompareTag("Border") || collision.CompareTag("Asteroid"))
        {
            // Destroys projectile
            Destroy(gameObject);
            // Checks tag again
            // Only called if colliding with an asteroid
            if (collision.CompareTag("Asteroid"))
            {
                // Destroys asteroid
                Destroy(collision.gameObject);
                // Increases score
                m_scoreSystem.AddScore(100);
            }
        }
    }
}
