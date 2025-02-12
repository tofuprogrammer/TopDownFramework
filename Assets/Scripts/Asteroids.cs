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

    void Update()
    {
        numberOfAsteroids = Random.Range(3, 6);
        asteroidToSpawn = Random.Range(1, asteroidPrefabs.Length + 1);
        SpawnAsteroid();
    }
    
    void SpawnAsteroid()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            if (asteroidToSpawn > 0 && asteroidToSpawn <= asteroidPrefabs.Length)
            {
                Instantiate(asteroidPrefabs[asteroidToSpawn - 1], transform.position, Quaternion.identity);
            }
        }
    }
}
