using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeEnemy : Enemy_Base
{
    protected override float EasingValue(float value)
    {
        return Easing.easeInOutBounce(value);
    }
}
