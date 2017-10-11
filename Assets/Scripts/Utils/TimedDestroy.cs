using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Destroy game object after certain amount of seconds
/// Attached to: MiniBullet
/// </summary>
public class TimedDestroy : MonoBehaviour {

    [SerializeField]
    private float destroyTimeout = 5;

    private void Awake()
    {
        Destroy(gameObject, destroyTimeout);
    }
}
