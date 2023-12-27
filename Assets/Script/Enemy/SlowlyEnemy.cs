using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyEnemy : Enemy_Base
{
    protected override float EasingValue(float value)
    {
        return Easing.easeOutCirc(value);
    }
}
