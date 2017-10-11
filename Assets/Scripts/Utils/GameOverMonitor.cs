using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/// <summary>
/// Author: LAB
/// Description:  A monitor for gameover state. It handle subsequent input when game is over
/// Attached to: GameOverMonitor
/// </summary>

public class GameOverMonitor : MonoBehaviour
{
    /// <summary>
    /// Enable this gameObject, also to enable the input behavior
    /// </summary>
    public void ShowGameOver()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (isActiveAndEnabled && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
