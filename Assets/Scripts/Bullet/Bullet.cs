using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: LAB
/// Description: Generic behavior of any bullet
/// Attached to: NormalBullet
/// </summary>
public class Bullet : MonoBehaviour
{
    internal AsteroidSystem asteroidSystemInstance;

    private float accelerationRate;

    private Vector3 direction;

    private Vector3 velocity;

    private Vector3 acceleration;

    /// <summary>
    /// Initialize Bullet's initial value
    /// </summary>
    /// <param name="accelerationRate"></param>
    /// <param name="direction"></param>
    /// <param name="velocity"></param>
    /// <param name="parentTransform"></param>
    internal void Init(
        float accelerationRate, 
        Vector3 direction, 
        Vector3 velocity,
        Transform parentTransform,
        AsteroidSystem asteroidSystemInstance
        )
    {
        this.accelerationRate = accelerationRate;
        this.direction = direction;
        this.velocity = velocity;
        transform.SetParent(parentTransform);

        this.asteroidSystemInstance = asteroidSystemInstance;
    }

    /// <summary>
    /// Move the bullet at passed down direction
    /// </summary>
    private void Move()
    {
        acceleration = direction * accelerationRate;

        velocity += acceleration;

        transform.position += velocity;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

}
