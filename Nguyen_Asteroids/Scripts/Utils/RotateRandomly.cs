using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Rotate the attached gameObject indefinitely
/// Attached to: AsteroidTypeY
/// </summary>
public class RotateRandomly : MonoBehaviour {

    private float rotationPerFrame;

    private void Awake()
    {
        rotationPerFrame = Random.Range(1f, 2f) * Random.value > 0.5f ? 1f : -1f;
    }

    /// <summary>
    /// Rotate the gameObject
    /// </summary>
    private void Rotate()
    {
        float rotateAngle = rotationPerFrame * Mathf.Rad2Deg * Time.deltaTime;

        float currentRotation = transform.eulerAngles.z;

        float degreeAngle = currentRotation - rotateAngle;

        transform.rotation = Quaternion.Euler(0, 0, degreeAngle);
    }

    private void Update()
    {
        Rotate();
    }
}
