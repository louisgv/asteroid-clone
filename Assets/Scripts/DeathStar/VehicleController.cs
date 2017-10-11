using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Apply vehicle movement behavior to the game object it is attached to.
/// Attached to: DeathStar
/// </summary>
public class VehicleController : MonoBehaviour
{
    internal Vector3 turretDirection = Vector3.up;

    internal Vector3 direction = Vector3.up;

    internal Vector3 velocity = Vector3.zero;

    private Vector3 acceleration = Vector3.zero;

    [SerializeField, Range(0, 1f)]
    internal float accelerationRate = 0.1f;

    [SerializeField, Range(0, 5f)]
    private float steeringSpeed = 1.0f;

    [SerializeField, Range(0, 1f)]
    private float staticVerticalAxis = 0.5f;

    [SerializeField, Range(0, 1f)]
    private float maxSpeed = 1.0f;

    [SerializeField, Range(0, 1f)]
    private float decelerationRate = 0.5f;

    [SerializeField]
    private Transform baseTransform;

    [SerializeField]
    private Transform turretTransform;

    /// <summary>
    /// Move the transform toward a direction
    /// </summary>
    /// <param name="direction"></param>
    private void Move(Vector3 direction)
    {
        this.direction = direction;

        acceleration = this.direction * accelerationRate;

        velocity += acceleration;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity;
    }

    /// <summary>
    /// Decrease the velocity
    /// </summary>
    private void Deceleration()
    {
        velocity *= decelerationRate;
    }

    /// <summary>
    /// Rotate the wheels and chassis toward the velocity direction
    /// </summary>
    /// <param name="direction"></param>
    private void RotateVehicleBase()
    {
        Vector3 direction = velocity.normalized;

        float degreeAngle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;

        if (degreeAngle == 0)
        {
            return;
        }

        baseTransform.rotation = Quaternion.Euler(0, 0, degreeAngle);
    }

    /// <summary>
    /// Move the user forward by the sensitivity from axis
    /// </summary>
    /// <param name="axisSensitivity"></param>
    private void Move(float axisSensitivity)
    {
        acceleration = axisSensitivity * direction * accelerationRate;

        velocity += acceleration;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity;
    }

    /// <summary>
    /// Rotate the base by a radius amount.
    /// </summary>
    /// <param name="rotation"></param>
    private void RotateVehicleBase(float rotation)
    {
        float rotateAngle = steeringSpeed * rotation * Mathf.Rad2Deg * Time.deltaTime;

        float currentRotation = baseTransform.eulerAngles.z;

        float degreeAngle = currentRotation - rotateAngle;

        Quaternion rotateQuaternion = Quaternion.Euler(Vector3.forward * -rotateAngle);

        baseTransform.rotation = Quaternion.Euler(0, 0, degreeAngle);

        direction = rotateQuaternion * direction;
    }

    /// <summary>
    /// Rotate the turret toward the mouse position
    /// </summary>
    /// <param name="direction"></param>
    private void RotateTurret()
    {
        var mouseWorldPos = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float degreeAngle = Mathf.Atan2(mouseWorldPos.x, -mouseWorldPos.y) * Mathf.Rad2Deg;

        turretTransform.rotation = Quaternion.Euler(0, 0, degreeAngle);

        turretDirection = turretTransform.rotation * Vector3.up;
    }

    // Update is called once per frame
    private void Update()
    {
        // Use the axis for an added input sensitivity
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        RotateVehicleBase(horizontalAxis);

        Move(verticalAxis);

        if (Input.GetKey(KeyCode.I))
        {
            Move(staticVerticalAxis);
        }
        else
        {
            Deceleration();
        }

        RotateTurret();
    }
}
