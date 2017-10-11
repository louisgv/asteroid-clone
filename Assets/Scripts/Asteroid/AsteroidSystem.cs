using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Spawn and manage asteroids.
/// Attached to: AsteroidSystem
/// </summary>
public class AsteroidSystem : MonoBehaviour
{
    /// <summary>
    /// Caching the player collider instance to avoid FindGameObjectWithTag call 
    /// in each Asteroid spawn
    /// </summary>
    [SerializeField]
    private DeathStarCollider playerCollider;

    [SerializeField]
    private List<Asteroid> asteroidPrefabs;

    private HashSet<Asteroid> asteroidInstanceSet;

    [SerializeField]
    private int asteroidMaxCount = 20;

    [SerializeField]
    private ScoreKeeper scoreKeeper;

    /// <summary>
    /// Expose the set of active asteroid for bullets to iterrate over
    /// </summary>
    /// <returns></returns>
    public HashSet<Asteroid> GetAsteroidSet()
    {
        return asteroidInstanceSet;
    }

    private void Awake()
    {
        asteroidInstanceSet = new HashSet<Asteroid>();
    }

    /// <summary>
    /// Spawn a random asteroid at a random position in the screen corner, with random acceleration, maxSpeed and direction
    /// </summary>
    private void SpawnAsteroid()
    {
        var asteroidPrefab = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Count)];
        Vector3 spawnPosition = Variables.RandomScreenBorderPosition(1);
        float accelerationRate = Random.value;
        float maxSpeed = Random.Range(0.005f, 0.05f);
        Vector3 direction = Random.insideUnitCircle;

        SpawnAsteroid(asteroidPrefab, spawnPosition, accelerationRate,
            maxSpeed, direction);
    }

    /// <summary>
    /// Spawns an asteroid with specified prefab, position, accelerationRate, maxSpeed and direction.
    /// </summary>
    /// <param name="asteroidPrefab">Asteroid prefab.</param>
    /// <param name="spawnPosition">Spawn position.</param>
    /// <param name="accelerationRate">Acceleration rate.</param>
    /// <param name="maxSpeed">Max speed.</param>
    /// <param name="direction">Direction.</param>
    public void SpawnAsteroid(Asteroid asteroidPrefab, Vector3 spawnPosition, float accelerationRate, float maxSpeed, Vector3 direction)
    {
        if (!isActiveAndEnabled) // Avoid complain from Garbage collector.
        {
            return;
        }
        var asteroidInstance = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        asteroidInstance.Init(accelerationRate, maxSpeed, direction,
            this, playerCollider, transform);

        asteroidInstanceSet.Add(asteroidInstance);
    }

    /// <summary>
    /// Remove an asteroid from the set
    /// </summary>
    /// <param name="instance"></param>
    public void RemoveAsteroid(Asteroid instance)
    {
        asteroidInstanceSet.Remove(instance);
    }

    /// <summary>
    /// Update score public method to be invoked by Asteroid collider upon their destruction
    /// </summary>
    /// <param name="health"></param>
    public void UpdateScore(int health)
    {
        if (health > 0)
        {
            scoreKeeper.AddScore(20f);
        }
        else
        {
            scoreKeeper.AddScore(50f);
        }
    }

    /// <summary>
    /// Spawn asteroid if the set is not full
    /// </summary>
    private void Update()
    {
        if (asteroidInstanceSet.Count < asteroidMaxCount * scoreKeeper.GetLevel())
        {
            SpawnAsteroid();
        }
    }

}
