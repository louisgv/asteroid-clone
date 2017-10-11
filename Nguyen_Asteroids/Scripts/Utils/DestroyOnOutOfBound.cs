using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: LAB
/// Description: Destroy any game object that is out of screen bound
/// Attached to: NormalBullet, AsteroidTypeX
/// </summary>
public class DestroyOnOutOfBound : MonoBehaviour {

    [SerializeField]
    private float destroyOffset = 0f;

    /// <summary>
    /// If the object is out of screen boundary, destroy it.
    /// </summary>
    private void DestroyIfOutOfBound()
    {
        Vector3 absPos = new Vector3(Mathf.Abs(transform.position.x), Mathf.Abs(transform.position.y), 0);
        if (absPos.x > Variables.screenConstraint.halfWidth + destroyOffset ||
            absPos.y > Variables.screenConstraint.halfHeight + destroyOffset)
        {
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
        DestroyIfOutOfBound();
    }
}
