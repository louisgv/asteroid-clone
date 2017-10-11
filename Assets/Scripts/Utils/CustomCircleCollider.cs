using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Custom circle collider for 2D game.
/// Attached to: N/A
/// </summary>
public class CustomCircleCollider : MonoBehaviour
{
    [SerializeField]
    internal ColliderType type;

    [SerializeField]
    internal float radius;

    /// <summary>
    /// Determines whether this instance is colliding with the specified other.
    /// </summary>
    /// <returns><c>true</c> if this instance is colliding with the specified other; otherwise, <c>false</c>.</returns>
    /// <param name="other">Other collider.</param>
    internal bool IsColliding(CustomCircleCollider other)
    {
        if (other == null ||
            !other.isActiveAndEnabled ||
            !isActiveAndEnabled) return false;

        Vector3 delta = transform.position - other.transform.position;

        float distanceSquared = Vector3.Dot(delta, delta);

        float radiusSum = radius + other.radius;

        return distanceSquared < radiusSum * radiusSum;
    }

    /// <summary>
    /// Checks the collision.
    /// Internal method to be overide by the specific collider component
    /// </summary>
    internal virtual void CheckCollision()
    {
    }

    // Update is called once per frame
    internal void Update()
    {
        CheckCollision();
    }
}

/// <summary>
/// Collider type.
/// Used to check player or asteroid or bullet
/// </summary>
public enum ColliderType
{
    PLAYER,
    ASTEROID,
    BULLET
}
