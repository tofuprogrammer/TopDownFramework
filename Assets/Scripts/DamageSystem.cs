using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private ScoreSystem m_scoreSystem;

    void Start()
    {
        m_scoreSystem = FindFirstObjectByType<ScoreSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border") || collision.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            if (collision.CompareTag("Asteroid"))
            {
                Destroy(collision.gameObject);
                m_scoreSystem.AddScore(200);
            }
        }
    }
}
