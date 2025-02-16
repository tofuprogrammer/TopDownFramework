using UnityEngine;

public class Asteroids : MonoBehaviour
{
    #region Asteroid Variables
    [Header("Asteroids")]
    [SerializeField] private GameObject[] asteroidPrefabs;
    private int asteroidToSpawn;
    private int numberOfAsteroids;
    [SerializeField] float m_minTimeBetweenSpawns = 2.0f;
    [SerializeField] float m_maxTimeBetweenSpawns = 5.0f;
    [SerializeField] float m_spawnDistance = 10.0f;
    [SerializeField] float m_minAsteroidSpeed = 1.0f;
    [SerializeField] float m_maxAsteroidSpeed = 3.0f;
    private GameObject Asteroid;
    private Vector2 asteroidDirection;
    private float asteroidSpeed;
    [SerializeField] float m_asteroidLifetime = 15.0f;
    #endregion
    
    [Header("Player")]
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        Invoke(nameof(SpawnAsteroids), Random.Range(m_minTimeBetweenSpawns, m_maxTimeBetweenSpawns));
    }

    private void SpawnAsteroids()
    {
        numberOfAsteroids = Random.Range(3, 6);
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            asteroidToSpawn = Random.Range(0, asteroidPrefabs.Length);
            Vector2 spawnPosition = (Vector2)playerTransform.position + Random.insideUnitCircle.normalized * m_spawnDistance;
            Asteroid = Instantiate(asteroidPrefabs[asteroidToSpawn], spawnPosition, Quaternion.identity);
            Rigidbody2D asteroidRigidbody = Asteroid.GetComponent<Rigidbody2D>();
            asteroidDirection = (playerTransform.position - Asteroid.transform.position).normalized;
            asteroidSpeed = Random.Range(m_minAsteroidSpeed, m_maxAsteroidSpeed);
            asteroidRigidbody.linearVelocity = asteroidDirection * asteroidSpeed;

            // Destroy the asteroid itself after the set lifetime
            Destroy(Asteroid, m_asteroidLifetime);
        }

        // Recursively call SpawnAsteroids
        Invoke(nameof(SpawnAsteroids), Random.Range(m_minTimeBetweenSpawns, m_maxTimeBetweenSpawns));
    }
}
