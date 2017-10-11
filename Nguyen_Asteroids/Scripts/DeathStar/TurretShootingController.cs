using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: LAB
/// Description: Let player shoot at mouse position with left mouse
/// Attached to: DeathStar
/// </summary>
public class TurretShootingController : ShootingController
{

    /// <summary>
    /// Dispatch a bullet with cached attackLevel at mouse direction
    /// </summary>
    internal override void DispatchBullet()
    {
        DispatchBullet(
           0.005f + attackLevel * 0.5f,
            vehicleController.turretDirection,
            Vector3.zero);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && isReadyToShoot)
        {
            StartCoroutine(Shoot());
        }
    }
}
