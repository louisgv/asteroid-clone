using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Collider for Asteroid. 
/// It detect colliding with player collider and destroy the gameObject if collision happens with player
/// If a bullet collided, it will spawn child asteroids
/// Attached to: AsteroidTypeX/Y/Z/C
/// </summary>
public class AsteroidCircleCollider : CustomCircleCollider
{

    private HealthSystem asteroidHealth;

    private Asteroid asteroidSelf;

    private void Awake()
    {
        asteroidHealth = GetComponent<HealthSystem>();
        asteroidSelf = GetComponent<Asteroid>();
    }
    /// <summary>
    /// Checks the collision.
    /// Checking if asteroid is colliding with player
    /// </summary>
    internal override void CheckCollision()
    {
        if (!IsColliding(asteroidSelf.playerCollider)) return;

        asteroidSelf.playerCollider.OnAsteroidColliding();

        Destroy(gameObject);
    }

    /// <summary>
    /// Callback method to handle on colliding event from Bullet 
    /// </summary>
    internal void OnBulletColliding()
    {
        asteroidHealth.DecreaseHealth();

        asteroidSelf.parentSystem.UpdateScore(asteroidHealth.GetHealth());

        Destroy(gameObject);

        if (asteroidHealth.IsAlreadyDead()) return;

        asteroidSelf.SpawnChildAsteroids();
    }
}
