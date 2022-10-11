using UnityEngine;

namespace Assets.Scripts.Pickups.PickupEffect
{
    public abstract class ApplyPickupEffects : ScriptableObject
    {
        public abstract void Apply(GameObject applyTo);
    }
}