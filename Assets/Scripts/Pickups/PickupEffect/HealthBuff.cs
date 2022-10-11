using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : ApplyPickupEffects
{
    public float amount;
    public override void Apply(GameObject applyTo)
    {
        //applyTo.GetComponent<PlayerHealth>().currentHealth.value += amount;
    }
}
