using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: LAB
/// Description: Generate and apply the deathstar base
/// Attached to: DeathStar -> Base
/// </summary>
public class DeathStarBaseSprite : MonoBehaviour
{

    [SerializeField]
    private int diameter = 100;

    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Generate parts of the base and assign it to the sprite renderer
    /// </summary>
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int outerOrbitDiameter = diameter * 9 / 10;

        int innerOrbitDiameter = diameter * 7 / 10;

        int pointerDiameter = diameter * 1 / 10;

        var spriteTexture = Draw.Circle(outerOrbitDiameter, Color.black);

        spriteTexture = Draw.AddCircle(spriteTexture, innerOrbitDiameter / 2, Color.white);

        spriteTexture = Draw.AddCircle(
            spriteTexture, spriteTexture.width / 2, spriteTexture.height - pointerDiameter, pointerDiameter / 2, Color.black);

        spriteTexture.Apply();

        spriteRenderer.sprite = Sprite.Create(
            spriteTexture,
            new Rect(0.0f, 0.0f, spriteTexture.width, spriteTexture.height),
            new Vector2(0.5f, 0.5f), 100.0f);
    }

}
