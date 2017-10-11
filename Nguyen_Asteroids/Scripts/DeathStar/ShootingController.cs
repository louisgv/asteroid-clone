using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Let player shoot at moving direction with space key
/// Attached to: DeathStar
/// </summary>
public class ShootingController : MonoBehaviour
{
    [SerializeField]
    internal string containerName = "Bullet Container";

    [SerializeField]
    internal List<Bullet> bulletPrefabs;

    internal int attackLevel = 0;

    internal VehicleController vehicleController;

    internal GameObject bulletContainer;

    [SerializeField, Range(0f, 5f)]
    internal float cooldownDuration;

    internal bool isReadyToShoot = true;

    [SerializeField]
    internal AsteroidSystem asteroidSystemInstance;

    /// <summary>
    /// Increase attack level
    /// </summary>
    public void IncreaseAttackLevel()
    {
        if (attackLevel < bulletPrefabs.Count)
        {
            attackLevel += 1;
        }
    }

    /// <summary>
    /// Decrease attack level
    /// </summary>
    public void DecreaseAttackLevel()
    {
        if (attackLevel > 0)
        {
            attackLevel -= 1;
        }
    }

    /// <summary>
    /// Get the active instance of vehicle controller for direction
    /// </summary>
    internal void Awake()
    {
        vehicleController = GetComponent<VehicleController>();
        bulletContainer = new GameObject(containerName);
    }

    /// <summary>
    /// Shoot a bullet at specified acceleration rate, direction and initial velocity
    /// </summary>
    /// <param name="accRate"></param>
    /// <param name="direction"></param>
    /// <param name="velocity"></param>
    internal void DispatchBullet(float accRate, Vector3 direction, Vector3 velocity)
    {
        var bulletPrefab = bulletPrefabs[attackLevel];

        var bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Bullet;

        bulletInstance.Init(accRate, direction, velocity, bulletContainer.transform, asteroidSystemInstance);
    }

    /// <summary>
    /// Shoot a bullet with cached attackLevel at vehicle direction
    /// </summary>
    internal virtual void DispatchBullet()
    {
        DispatchBullet(
            vehicleController.accelerationRate + 0.5f * attackLevel,
            vehicleController.direction,
            vehicleController.velocity);
    }

    /// <summary>
    /// Shoot a bullet
    /// </summary>
    internal IEnumerator Shoot()
    {
        DispatchBullet();

        isReadyToShoot = false;

        yield return new WaitForSeconds(cooldownDuration);

        isReadyToShoot = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isReadyToShoot)
        {
            StartCoroutine(Shoot());
        }
    }

}
