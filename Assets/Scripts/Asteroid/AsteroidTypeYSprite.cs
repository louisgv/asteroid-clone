using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: LAB
/// Description: Render asteroid with a Y pattern
/// Attached to: AsteroidTypeY

public class AsteroidTypeYSprite : AsteroidSprite {

    internal override Texture2D GenerateTexture(int thickness)
    {
        return Draw.ClockStar(size, color, thickness);
    }
}
