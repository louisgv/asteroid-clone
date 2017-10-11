using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: Render asteroid with an X pattern (4 corner star)
/// Attached to: AsteroidTypeX
/// </summary>
public class AsteroidTypeXSprite : AsteroidSprite
{
    internal override Texture2D GenerateTexture(int thickness)
    {
        return Draw.FourCornerStar(size, color, thickness);
    }

}
