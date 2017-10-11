using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Generate a normal Bullet
/// Attached to: NormalBullet
/// </summary>
public class NormalBulletSprite : MonoBehaviour {

    [SerializeField]
    private int diameter = 30;

    [SerializeField]
    private Color color = Color.white;

    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Generate the bullet and assign it to the sprite renderer
    /// </summary>
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Generate the texture with outer orbit
        var spriteTexture = Draw.Circle(diameter, color);

        spriteTexture.Apply();

        // Apply the sprite
        spriteRenderer.sprite = Sprite.Create(
            spriteTexture,
            new Rect(0.0f, 0.0f, spriteTexture.width, spriteTexture.height),
            new Vector2(0.5f, 0.5f), 100.0f);
    }

}
