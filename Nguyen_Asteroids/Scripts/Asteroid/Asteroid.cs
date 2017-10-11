using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Generic behavior of all Asteroid
/// Attached to: AsteroidSystem
/// </summary>
public class Asteroid : MonoBehaviour
{
    internal new AsteroidCircleCollider collider;

    internal AsteroidSystem parentSystem;

    internal DeathStarCollider playerCollider;

    [SerializeField]
    private List<Asteroid> childAsteroidPrefabs;

    private float accelerationRate;

    private float maxSpeed;

    private Vector3 direction;

    private Vector3 velocity = Vector3.zero;

    private Vector3 acceleration = Vector3.zero;

    [SerializeField]
    private int childCountMax = 3;

    /// <summary>
    /// Remove itself from the asteroid set
    /// </summary>
    private void OnDestroy()
    {
        if (parentSystem != null)
        {
            parentSystem.RemoveAsteroid(this);
        }
    }

    private void Awake()
    {
        collider = GetComponent<AsteroidCircleCollider>();
    }

    /// <summary>
    /// Initialize Asteroid's initial value
    /// </summary>
    /// <param name="accelerationRate"></param>
    /// <param name="maxSpeed"></param>
    /// <param name="direction"></param>
    /// <param name="parentSystem"></param>
    /// <param name="playerCollider"></param>
    /// <param name="parentTransform"></param>
    public void Init(
        float accelerationRate,
        float maxSpeed,
        Vector3 direction,
        AsteroidSystem parentSystem,
        DeathStarCollider playerCollider,
        Transform parentTransform
        )
    {
        this.accelerationRate = accelerationRate;

        this.maxSpeed = maxSpeed;

        this.direction = direction;

        this.parentSystem = parentSystem;

        this.playerCollider = playerCollider;

        transform.SetParent(parentTransform);
    }

    /// <summary>
    /// Spawn child asteroids up to a random max amount of child
    /// </summary>
    public void SpawnChildAsteroids()
    {
        int childCount = Random.Range(2, childCountMax);
        for (int i = 0; i <= childCount; i++)
        {
            SpawnChildAsteroid();
        }
    }

    /// <summary>
    /// Spawns some child asteroid using the parent asteroid system.
    /// </summary>
    public void SpawnChildAsteroid()
    {
        if (childAsteroidPrefabs == null || childAsteroidPrefabs.Count <= 0) return;

        var asteroidPrefab = childAsteroidPrefabs[Random.Range(0, childAsteroidPrefabs.Count)];

        Vector3 spawnPosition = transform.position;

        float spawnAccelerationRate = Random.value;

        float spawnMaxSpeed = Random.Range(0.005f, 0.05f);

        Vector3 localRight = Vector3.Cross(direction, Vector3.forward).normalized;

        Vector3 spawnDirection = (direction + localRight * Random.Range(-0.5f, 0.5f)).normalized;

        parentSystem.SpawnAsteroid(asteroidPrefab, spawnPosition, spawnAccelerationRate, spawnMaxSpeed, spawnDirection);
    }

    /// <summary>
    /// Move the asteroid toward the random direction
    /// </summary>
    private void Move()
    {
        acceleration = direction * accelerationRate;

        velocity += acceleration;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity;
    }

    private void Update()
    {
        Move();
    }
}
