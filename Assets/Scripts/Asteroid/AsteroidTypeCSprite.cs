using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: LAB
/// Description: Render asteroid with a C pattern (Clover)
/// Attached to: AsteroidTypeC
public class AsteroidTypeCSprite : AsteroidSprite {

    internal override Texture2D GenerateTexture(int thickness)
    {
        return Draw.CloverStar(size, color, thickness);
    }

}
