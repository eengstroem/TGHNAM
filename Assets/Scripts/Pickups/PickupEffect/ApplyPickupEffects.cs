using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ApplyPickupEffects : ScriptableObject
{
    public abstract void Apply(GameObject applyTo);
}
