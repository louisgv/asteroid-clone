using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: DeathStar collider.
/// Attached to: DeathStar
/// </summary>
public class DeathStarCollider : CustomCircleCollider
{
	private HealthSystem playerHealth;

	private void Awake ()
	{
		playerHealth = GetComponent <HealthSystem> ();
	}

    /// <summary>
    /// Callback method to handle on colliding event from Asteroid
    /// </summary>
	internal void OnAsteroidColliding ()
	{
        playerHealth.DecreaseHealth();
        if (playerHealth.IsAlreadyDead())
        {
            Destroy(gameObject);
        }
    }
}
