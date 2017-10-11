using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: LAB
/// Description: A static helper class to generate Texture2D
/// Attached to: N/A
/// </summary>
public class Draw
{
    /// <summary>
    /// Generate a triangle
    /// </summary>
    /// <param name="size"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public static Texture2D Triangle(int size, Color col, int thickness = 5)
    {
        Texture2D output = EmptySquareTexture(size);

        int x;
        int y;

        for (x = 0; x < size; x++)
        {
            for (y = 0; y < thickness; y++)
            {
                output.SetPixel(x, y, col);
                output.SetPixel(-x, x + y, col);
                output.SetPixel(size + y, size + x, col);
            }
        }

        return output;
    }

    /// <summary>
    /// Generate a solid triangle
    /// </summary>
    /// <param name="size"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public static Texture2D SolidTriangle(int size, Color col)
    {
        Texture2D output = EmptySquareTexture(size);

        int x;
        int y;

        for (x = 0; x < size; x++)
        {
            for (y = 0; y < x; y++)
            {
                output.SetPixel(x, y, col);
            }
        }

        return output;
    }

    /// <summary>
    /// Generate a three corner star
    /// </summary>
    /// <param name="size"></param>
    /// <param name="col"></param>
    /// <param name="thickness"></param>
    /// <returns></returns>
    public static Texture2D ClockStar(int size, Color col, int thickness = 5)
    {
        Texture2D output = EmptySquareTexture(size);
        int radius = size;

        int cx = -size / 2;
        int cy = size;

        return AddCircle(output, cx, cy, radius, col, thickness);
    }

    /// <summary>
    /// Generate a clover star
    /// </summary>
    /// <param name="size"></param>
    /// <param name="col"></param>
    /// <param name="thickness"></param>
    /// <returns></returns>
    public static Texture2D CloverStar(int size, Color col, int thickness = 5)
    {
        Texture2D output = EmptySquareTexture(size);
        int radius = size;

        int cx = size / 2;
        int cy = size / 2;

        return AddCircle(output, cx, cy, radius, col, thickness);
    }

    /// <summary>
    /// Generate a star with corner circle
    /// </summary>
    /// <param name="size"></param>
    /// <param name="col"></param>
    /// <param name="thickness"></param>
    /// <returns></returns>
    public static Texture2D CornerCircleStar(int size, Color col, int thickness = 5)
    {
        Texture2D output = EmptySquareTexture(size);
        int radius = size / 8;
        Vector2 center = Vector2.one * radius;

        return AddCircle(output, center, radius, col, thickness);
    }

    /// <summary>
    /// Generate a four corner star
    /// </summary>
    /// <param name="size"></param>
    /// <param name="col"></param>
    /// <param name="thickness"></param>
    /// <returns></returns>
    public static Texture2D FourCornerStar(int size, Color col, int thickness = 5)
    {
        Texture2D output = EmptySquareTexture(size);
        int radius = size;
        Vector2 center = Vector2.one * radius;

        return AddCircle(output, center, radius, col, thickness);
    }

    /// <summary>
    /// Generate a Texture2D with a circle in it
    /// Code adapted from http://wiki.unity3d.com/index.php?title=TextureDrawCircle
    /// </summary>
    /// <param name="diameter"></param>
    /// <param name="color"></param>
    /// <returns>An unapplied texture</returns>
    public static Texture2D Circle(int diameter, Color col, int thickness = 5)
    {
        Texture2D output = EmptySquareTexture(diameter);
        int radius = diameter / 2;
        Vector2 center = Vector2.one * radius;

        return AddCircle(output, center, radius, col, thickness);
    }

    /// <summary>
    /// Add circle to existing texture using vector2 as position
    /// </summary>
    /// <param name="output"></param>
    /// <param name="center">center of circle</param>
    /// <param name="radius"></param>
    /// <param name="col">color of circle</param>
    /// <returns></returns>
    public static Texture2D AddCircle(
        Texture2D output, Vector2 center, int radius, Color col, int thickness = 5)
    {
        return AddCircle(output, (int)center.x, (int)center.y, radius, col, thickness);
    }

    /// <summary>
    /// Add circle at the center of existing texture
    /// </summary>
    /// <param name="output"></param>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public static Texture2D AddCircle(
       Texture2D output, int radius, Color col, int thickness = 5)
    {
        return AddCircle(output, output.width / 2, output.height / 2, radius, col, thickness);
    }

    /// <summary>
    /// Add circle to an existing Texture
    /// </summary>
    /// <param name="output"></param>
    /// <param name="cx">Center x</param>
    /// <param name="cy">Center y</param>
    /// <param name="radius"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public static Texture2D AddCircle(
        Texture2D output, int cx, int cy, int radius, Color col, int thickness = 5)
    {
        int y = radius;

        float d = 1 / 4 - y;

        int end = (int)Mathf.Ceil(radius / Mathf.Sqrt(2));

        for (int x = 0; x <= end; x++)
        {
            for (int t = 0; t < thickness; t++)
            {
                output.SetPixel(cx + x - t, cy + y - t, col);
                output.SetPixel(cx + x - t, cy - y + t, col);

                output.SetPixel(cx - x + t, cy + y - t, col);
                output.SetPixel(cx - x - t, cy - y + t, col);

                output.SetPixel(cx + y - t, cy + x - t, col);
                output.SetPixel(cx - y + t, cy + x - t, col);

                output.SetPixel(cx + y - t, cy - x + t, col);
                output.SetPixel(cx - y + t, cy - x + t, col);
            }

            d += 2 * x + 1;
            if (d > 0)
            {
                d += 2 - 2 * y--;
            }
        }

        return output;
    }

    /// <summary>
    /// Create a solid circle
    /// </summary>
    /// <param name="diameter"></param>
    /// <param name="col">color</param>
    /// <returns></returns>
    public static Texture2D SolidCircle(int diameter, Color col)
    {
        Texture2D output = EmptySquareTexture(diameter);

        int radius = diameter / 2;

        return AddSolidCircle(output, radius, radius, radius, col);
    }

    /// <summary>
    /// Add solid circle at the center
    /// </summary>
    /// <param name="tex"></param>
    /// <param name="r"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public static Texture2D AddSolidCircle(Texture2D tex, int r, Color col)
    {
        return AddSolidCircle(tex, tex.width / 2, tex.height / 2, r, col);
    }

    /// <summary>
    /// Add a solid circle into existing texture
    /// Code adapted from http://answers.unity3d.com/questions/590469/drawing-a-solid-circle-onto-texture.html
    /// </summary>
    /// <param name="tex"></param>
    /// <param name="cx"></param>
    /// <param name="cy"></param>
    /// <param name="r"></param>
    /// <param name="col"></param>
    public static Texture2D AddSolidCircle(Texture2D tex, int cx, int cy, int r, Color col)
    {
        int x = 0;
        int y = 0;
        int px = 0;
        int nx = 0;
        int py = 0;
        int ny = 0;
        int d = 0;

        int rSqrt = r * r;

        for (x = 0; x <= r; x++)
        {
            d = (int)Mathf.Ceil(Mathf.Sqrt(rSqrt - x * x));
            for (y = 0; y <= d; y++)
            {
                px = cx + x;
                nx = cx - x;
                py = cy + y;
                ny = cy - y;

                tex.SetPixel(px, py, col);
                tex.SetPixel(nx, py, col);

                tex.SetPixel(px, ny, col);
                tex.SetPixel(nx, ny, col);
            }
        }
        return tex;
    }

    /// <summary>
    /// Return an empty texture with transparent background
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    static Texture2D EmptySquareTexture(int size)
    {
        Texture2D output = new Texture2D(size, size, TextureFormat.ARGB32, false);

        Color fillColor = Color.clear;
        Color[] fillPixels = new Color[output.width * output.height];

        for (int i = 0; i < fillPixels.Length; i++)
        {
            fillPixels[i] = fillColor;
        }

        output.SetPixels(fillPixels);

        return output;
    }

}
