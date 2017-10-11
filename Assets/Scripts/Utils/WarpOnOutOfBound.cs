using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: LAB
/// Description: Wrap the game object back to the screen boundary
/// Attached to: DeathStar, MiniBullet
/// </summary>
public class WarpOnOutOfBound : MonoBehaviour {

    /// <summary>
    /// Wrap the object within the screen constraint
    /// </summary>
    private void Wrap()
    {
        // Getting the absolute position of the user
        // Since the anchor in Unity is zero, this will reduce checking logic
        Vector3 absPos = new Vector3(Mathf.Abs(transform.position.x), Mathf.Abs(transform.position.y), 0);

        // Setup a wrap factor which is a vector3 of 
        // signs for each direction.
        Vector3 wrapFactor = new Vector3(
                absPos.x > Variables.screenConstraint.halfWidth ? -1 : 1,
                absPos.y > Variables.screenConstraint.halfHeight ? -1 : 1,
                0
            );

        transform.position = Vector3.Scale(transform.position, wrapFactor);

        /* An easier to understand version is as follow:
         * 
        if (absPos.x > screenConstraint.halfWidth)
        {
            transform.position = Vector3.Scale(transform.position, -1 * Vector3.right);
        }

        if (absPos.y > screenConstraint.halfHeight)
        {
            transform.position = Vector3.Scale(transform.position, -1 * Vector3.up);
        } 
         */
    }

    private void Update()
    {
        Wrap();
    }

}
