using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemy : Enemy_Base
{
    protected override float EasingValue(float value)
    {
        return Easing.easeInOutQuint(value);
    }
}
