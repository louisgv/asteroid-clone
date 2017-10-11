using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: LAB
/// Description: Score tracker UI, get updated from foreign actors
/// Attached to: ScoreKeeper
/// </summary>
public class ScoreKeeper : MonoBehaviour
{

    [SerializeField]
    private Text textShadow;

    [SerializeField]
    private Text text;

    private float score = 0;

    [SerializeField]
    private HealthSystem playerHealth;

    private int level = 1;

    /// <summary>
    /// Add score to current score
    /// </summary>
    /// <param name="value"></param>
    public void AddScore(float value)
    {
        score += value;

        if (score > 999f * level)
        {
            playerHealth.IncreaseHealth();
            level++;
        }

        string scoreText = ConstructScoreText(score);

        text.text = scoreText;

        textShadow.text = scoreText;
    }

    /// <summary>
    /// Construct the Score text with format:
    ///  "SCORE: 000099999"
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private string ConstructScoreText(float value)
    {
        return "SCORE: " + value.ToString("F0").PadLeft(9, '0');
    }
}
