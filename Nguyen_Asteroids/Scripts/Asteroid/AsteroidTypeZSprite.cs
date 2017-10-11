using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: LAB
/// Description: Render asteroid with a Triangle pattern
/// Attached to: AsteroidTypeZ

public class AsteroidTypeZSprite : AsteroidSprite
{
    internal override Texture2D GenerateTexture(int thickness)
    {
        return Draw.Triangle(size, Random.value > 0.5f ? Color.black : Color.white, thickness);
    }
}
