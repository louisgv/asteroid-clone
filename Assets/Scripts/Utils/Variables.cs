using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Helper class to retrieve global variables.
/// Attached to: N/A
/// </summary>
public class Variables {

    public static Constraint screenConstraint = CalculateScreenConstraint();

    /// <summary>
    /// Grab the camera constraint, for 2D game it's the same accross Z
    /// </summary>
    /// <returns>Camera contrainst for our screen</returns>
    private static Constraint CalculateScreenConstraint()
    {
        Vector3 cameraBoundary = Camera.main.ScreenToWorldPoint(Vector3.zero);

        return new Constraint()
        {
            halfWidth = -cameraBoundary.x,
            halfHeight = -cameraBoundary.y
        };
    }

    /// <summary>
    /// Return a random side of the screen
    /// </summary>
    /// <returns></returns>
    public static BorderSide RandomSide()
    {
        return (BorderSide)Random.Range(0,4);
    }

    /// <summary>
    /// Return a random position on the broder of the screen
    /// </summary>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static Vector3 RandomScreenBorderPosition(float offset)
    {
        BorderSide randomBorderSide = Variables.RandomSide();

        float randomScreenX = Random.Range(-screenConstraint.halfWidth, screenConstraint.halfWidth);

        float randomScreenY = Random.Range(-screenConstraint.halfHeight, screenConstraint.halfHeight);

        switch (randomBorderSide)
        {
            case BorderSide.TOP:
                return new Vector3(randomScreenX, screenConstraint.halfHeight + offset, 0);
            case BorderSide.BOTTOM:
                return new Vector3(randomScreenX, -screenConstraint.halfHeight - offset, 0);
            case BorderSide.LEFT:
                return new Vector3(-screenConstraint.halfWidth - offset, randomScreenY, 0);
            case BorderSide.RIGHT:
                return new Vector3(screenConstraint.halfWidth + offset, randomScreenY, 0);
            default:
                return new Vector3(0, screenConstraint.halfHeight + offset, 0);
        }
    }
}

/// <summary>
/// Side of the screen
/// </summary>
public enum BorderSide
{
    TOP = 0,
    LEFT = 1,
    BOTTOM = 2,
    RIGHT = 3
}

/// <summary>
/// This struct hold the half widht of a screen
/// </summary>
public struct Constraint
{
    public float halfWidth;
    public float halfHeight;
}