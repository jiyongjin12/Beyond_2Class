using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easing : MonoBehaviour
{
    public static float easeInQuint(float x) => x * x * x * x * x;
    public static float easeOutQuint(float x) => 1 - Mathf.Pow(1 - x, 5);
    public static float easeOutSine(float x) => Mathf.Sin((x * Mathf.PI) / 2);
    public static float easeOutCirc(float x) => Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
    public static float easeInBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return c3 * x * x * x - c1 * x * x;
    }
    public static float easeOutBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;

        return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }
    public static float easeOutBounce(float x)
    {
        float n1 = 7.5625f;
        float d1 = 2.75f;

        if (x < 1 / d1)
        {
            return n1 * x * x;
        }
        else if (x < 2 / d1)
        {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        }
        else if (x < 2.5 / d1)
        {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        }
        else
        {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }
    public static float easeInOutQuart(float x) => x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
    public static float easeInOutBack(float x)
    {
        float c1 = 1.70158f;
        float c2 = c1 * 1.525f;

        return x < 0.5
          ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
          : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
    }
    public static float easeInOutQuint(float x) => x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
    public static float easeInOutBounce(float x)
    {
        return x < 0.5 ? (1 - easeOutBounce(1 - 2 * x)) / 2 : (1 + easeOutBounce(2 * x - 1)) / 2;
    }
}
