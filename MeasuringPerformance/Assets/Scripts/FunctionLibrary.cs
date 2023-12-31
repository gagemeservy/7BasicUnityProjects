using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate Vector3 Function(float u, float v, float t);

    public enum FunctionName { Wave, MultiWave, Ripple, Sphere, Torus, Tornado, Tornado2 }

    static Function[] functions = { Wave, MultiWave, Ripple, Sphere, Torus, Tornado, Tornado2 };
    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name];
    }
    public static Vector3 Wave(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;

        return p;
    }

    public static Vector3 MultiWave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + .5f * t));
        p.y += .5f * Sin(2f * PI * (v + t));
        p.y += Sin(PI * (u + v + .25f * t));
        p.y *= (1f / 2.5f);
        p.z = v;

        return p;
    }

    public static Vector3 Ripple(float u, float v, float t)
    {
        float d = Sqrt(u * u + v * v);

        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d - t));
        p.y /= (1f + 10f * d);
        p.z = v;
        return p;
    }

    public static Vector3 Sphere(float u, float v, float t)
    {
        float r = .9f + .1f * Sin(PI * (6f * u + 4f * v + t));
        float s = r * Cos(.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * .5f * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 Torus(float u, float v, float t)
    {
        float r1 = .7f + .1f * Sin(PI * (6f * u + .5f * t));
        float r2 = .15f + .05f * Sin(PI * (8f * u + 4f * v + 2f * t));
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    //Here are functions that I added on my own for fun
    public static Vector3 Tornado(float u, float v, float t)
    {
        float r1 = 1/Tan(u + t);
        float r2 = Tan(v * .5f - t);
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 Tornado2(float u, float v, float t)
    {
        float r = .9f + .1f * Sin(PI * (6f * u + 4f * v + t));
        float s = r * Cos(.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u * t);
        p.y = 1/(10f *(r * Sin(PI * .5f * v)));
        p.z = s * Cos(PI * u * t);
        return p;
    }

    public static FunctionName GetNextFunctionName(FunctionName name)
    {
        return (int)name < functions.Length - 1 ? name + 1: 0;
    }

    public static FunctionName GetRandomFunctionNameOtherThan(FunctionName name)
    {
        var choice = (FunctionName)UnityEngine.Random.Range(1, functions.Length);
        return choice == name ? 0 : choice;
    }

    public static Vector3 Morph (float u, float v, float t, Function from, Function to, float progress)
    {
        return Vector3.LerpUnclamped(from(u,v,t), to(u,v,t), SmoothStep(0f, 1f, progress));
    }
}
