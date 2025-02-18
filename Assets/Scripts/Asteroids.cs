using UnityEngine;

public class Asteroids : MonoBehaviour
{
    #region Asteroid Variables
    [Header("Spawning")]
    [SerializeField] private GameObject[] m_asteroidPrefabs;
    [SerializeField] private float m_minTimeBetweenSpawns = 2.0f;
    [SerializeField] private float m_maxTimeBetweenSpawns = 5.0f;
    // Asteroid's distance from the player when spawned
    [SerializeField] private float m_spawnDistance = 10.0f;
    [SerializeField] private float m_minAsteroidSpeed = 1.0f;
    [SerializeField] private float m_maxAsteroidSpeed = 3.0f;
    // Time to automatic asteroid destruction
    [SerializeField] private float m_asteroidLifetime = 15.0f;
    private int m_asteroidToSpawn;
    private int m_numberOfAsteroids;
    private GameObject m_asteroid;
    private Vector2 m_asteroidDirection;
    private float m_asteroidSpeed;
    #endregion
    
    // Player location
    [SerializeField] private Transform m_playerTransform;
    
    private void Start()
    {
        // Starts asteroid spawning
        Invoke(nameof(SpawnAsteroids), Random.Range(m_minTimeBetweenSpawns, m_maxTimeBetweenSpawns));
    }

    /// <summary>
    /// Spawns a group of asteroids and fires them at the player
    /// </summary>
    private void SpawnAsteroids()
    {
        m_numberOfAsteroids = Random.Range(3, 6);
        for (int i = 0; i < m_numberOfAsteroids; i++)
        {
            // Checks if the player's location is valid
            if (m_playerTransform)
            {
                // Picks a random asteroid
                m_asteroidToSpawn = Random.Range(0, m_asteroidPrefabs.Length);
                // Draws a circle around the player on which asteroids can spawn
                Vector2 spawnPosition = (Vector2)m_playerTransform.position + Random.insideUnitCircle.normalized * m_spawnDistance;
                // Spawns a new asteroid instance
                m_asteroid = Instantiate(m_asteroidPrefabs[m_asteroidToSpawn], spawnPosition, Quaternion.identity);
                Rigidbody2D asteroidRigidbody = m_asteroid.GetComponent<Rigidbody2D>();
                // Calculates a vector to direct the asteroid towards the player
                m_asteroidDirection = (m_playerTransform.position - m_asteroid.transform.position).normalized;
                m_asteroidSpeed = Random.Range(m_minAsteroidSpeed, m_maxAsteroidSpeed);
                // Adds velocity to the asteroid instance
                asteroidRigidbody.linearVelocity = m_asteroidDirection * m_asteroidSpeed;
                // Destroys the asteroid after the set lifetime
                Destroy(m_asteroid, m_asteroidLifetime);
            }
        }
        // Recursively call SpawnAsteroids
        Invoke(nameof(SpawnAsteroids), Random.Range(m_minTimeBetweenSpawns, m_maxTimeBetweenSpawns));
    }
}
