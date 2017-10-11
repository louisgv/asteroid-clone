using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Author: LAB
/// Description: Base Asteroid Sprite class
/// Attached to: AsteroidTypeY
public class AsteroidSprite : MonoBehaviour {

    [SerializeField]
    internal int maxThickness = 50;

    [SerializeField]
    internal int size = 100;

    [SerializeField]
    internal Color color = Color.white;

    internal SpriteRenderer spriteRenderer;

    /// <summary>
    /// Generate the final asteroid texture
    /// </summary>
    /// <param name="thickness"></param>
    /// <returns></returns>
    internal virtual Texture2D GenerateTexture(int thickness)
    {
        return Draw.ClockStar(size, color, thickness);
    }

    /// <summary>
    /// Generate the asteroid and assign it to the sprite renderer
    /// </summary>
    internal void Awake()
    {
        int thickness = Mathf.RoundToInt(Random.Range(0.1f, 1.0f) * maxThickness);

        spriteRenderer = GetComponent<SpriteRenderer>();

        // Generate the texture with outer orbit
        var spriteTexture = GenerateTexture(thickness);

        spriteTexture.Apply();

        // Apply the sprite
        spriteRenderer.sprite = Sprite.Create(
            spriteTexture,
            new Rect(0.0f, 0.0f, spriteTexture.width, spriteTexture.height),
            new Vector2(0.5f, 0.5f), 100.0f);
    }
}