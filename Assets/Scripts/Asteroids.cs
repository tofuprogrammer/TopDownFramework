using System.Security.Cryptography;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    #region Asteroid Variables
    [Header("Asteroids")]
    [SerializeField] private GameObject[] asteroidPrefabs;
    private int asteroidToSpawn;
    private int numberOfAsteroids;
    #endregion

    void Start()
    {
        Invoke(nameof(SpawnAsteroid), Random.Range(2.0f, 5.0f));
    }
    
    void Update()
    {
        
        
    }
    
    void SpawnAsteroid()
    {
        numberOfAsteroids = Random.Range(3, 6);
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            asteroidToSpawn = Random.Range(1, asteroidPrefabs.Length + 1);
            
            if (asteroidToSpawn > 0 && asteroidToSpawn <= asteroidPrefabs.Length)
            {
                Instantiate(asteroidPrefabs[asteroidToSpawn - 1], transform.position, Quaternion.identity);
            }
        }
        Invoke(nameof(SpawnAsteroid), Random.Range(2.0f, 5.0f));
    }
}
