using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Generate the DeathStar's turret
/// Attached to: DeathStar -> Turret
/// </summary>
public class DeathStarTurretSprite : MonoBehaviour {

    [SerializeField]
    private int diameter = 100;

    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Generate parts of the turret and assign it to the sprite renderer
    /// </summary>
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int outerOrbitDiameter = diameter * 9 / 10;

        int bodyDiameter = diameter * 7 / 10;

        int coreDiameter = diameter * 4 / 10;

        int pointerDiameter = diameter * 1 / 10;

        // Generate the texture with outer orbit
        var spriteTexture = Draw.Circle(outerOrbitDiameter, Color.black);

        // Draw the body
        spriteTexture = Draw.AddSolidCircle(spriteTexture, bodyDiameter/2, Color.black);

        // Draw the core
        spriteTexture = Draw.AddCircle(spriteTexture, coreDiameter/2, Color.white);

        // Add the pointer for shooting direction indicator
        spriteTexture = Draw.AddCircle(
            spriteTexture, spriteTexture.width/2, spriteTexture.height - pointerDiameter, pointerDiameter/2, Color.white);

        spriteTexture.Apply();

        // Apply the sprite
        spriteRenderer.sprite = Sprite.Create(
            spriteTexture,
            new Rect(0.0f, 0.0f, spriteTexture.width, spriteTexture.height),
            new Vector2(0.5f, 0.5f), 100.0f);
    }
}
