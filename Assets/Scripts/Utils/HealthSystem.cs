using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Health system, used to track health.
/// Attached to: DeathStar
/// </summary>
public class HealthSystem : MonoBehaviour
{
	[SerializeField]
	private int health = 3;

    [SerializeField]
    private HealthMonitor monitor;

	/// <summary>
	/// Gets the health.
	/// </summary>
	/// <returns>The health.</returns>
	public int GetHealth ()
	{
		return health;
	}

	/// <summary>
	/// Determines whether this instance is already dead.
	/// </summary>
	/// <returns><c>true</c> if this instance is already dead; otherwise, <c>false</c>.</returns>
	public bool IsAlreadyDead ()
	{
		return health <= 0;
	}

	/// <summary>
	/// Decreases the health.
	/// </summary>
	public void DecreaseHealth ()
	{
		health--;
        if (monitor != null)
        {
            monitor.UpdateHealth(health);
        }
	}

	/// <summary>
	/// Increases the health.
	/// </summary>
	public void IncreaseHealth ()
	{
		health++;
        if (monitor != null)
        {
            monitor.UpdateHealth(health);
        }
    }
}
