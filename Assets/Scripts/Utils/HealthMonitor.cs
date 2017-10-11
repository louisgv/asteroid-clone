using System;
using System.Linq;
using UnityEngine;

using UnityEngine.UI;

/// <summary>
/// Author: LAB
/// Description: Health monitor UI, get updated from foreign actors. It also toggle the gameover state
/// Attached to: HealthMonitor
/// </summary>
public class HealthMonitor : MonoBehaviour
{
    [SerializeField]
    private Text lifeShadow;

    [SerializeField]
    private Text life;

    [SerializeField]
    private GameOverMonitor gameOverMonitor;

    /// <summary>
    /// Let foreign actor change the health value
    /// </summary>
    /// <param name="value"></param>
    public void UpdateHealth(int value)
    {
        string lifeText = ConstructHealthText(value);

        life.text = lifeText;

        lifeShadow.text = lifeText;
    }

    /// <summary>
    /// Construct the health text with format:
    ///  "LIFE: O = O = O"
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private string ConstructHealthText(int value)
    {
        if (value == 0)
        {
            gameOverMonitor.ShowGameOver();
            return "YOU ARE ALREADY DEAD!";
        }

        string lifeText = "LIFE: ";
        for (int i = 0; i < value - 1; i++)
        {
            lifeText += "O = ";
        }
        lifeText += "O";
        return lifeText;
    }

}
