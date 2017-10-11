using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Bullet Collider.
/// Attached to: DeathStar 
/// </summary>
public class BulletCircleCollider : CustomCircleCollider
{
    private Bullet bulletSelf;

    private void Awake()
    {
        bulletSelf = GetComponent<Bullet>();
    }

    /// <summary>
    /// Checks the collision with all available asteroids.
    /// </summary>
    internal override void CheckCollision()
    {
        var asteroidSet = bulletSelf.asteroidSystemInstance.GetAsteroidSet();

        Asteroid collidedAsteroid = null;

        foreach (Asteroid asteroid in asteroidSet)
        {
            if (asteroid != null && IsColliding(asteroid.collider))
            {
                collidedAsteroid = asteroid;
            }
        }

        if (collidedAsteroid != null)
        {
            collidedAsteroid.collider.OnBulletColliding();
            Destroy(gameObject);
        }
    }

}
