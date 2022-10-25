using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public static event Action OnPlayerDeath;
        public float maxHealth;
        public float currentHealth;
        public float healthRegen = 1f;

        public float collisionInvulnerabilityTime, projectileInvulnerabilityTime, miscInvulnerabilityTime = 0.1f;
        private float collisionDamageTime, projectileDamageTime, miscDamageTime;
        
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
        }

        void Update()
        {
            currentHealth += healthRegen * Time.deltaTime;
        }
        
        public enum EDamageType
        {
            COLLISION,
            PROJECTILE,
            MISC
        }

        public void TakeDamage(int amount, EDamageType type)
        {
            var now = Time.time;
            
            switch (type) { 
                case EDamageType.COLLISION:
                    if (now <= collisionDamageTime + collisionInvulnerabilityTime)
                        return;
                    break;
                case EDamageType.PROJECTILE:
                    if (now <= projectileDamageTime + projectileInvulnerabilityTime)
                        return;
                    break;
                case EDamageType.MISC:
                    if (now <= miscDamageTime + miscInvulnerabilityTime)
                        return;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            collisionDamageTime = now;

            currentHealth -= amount;

            if (!(currentHealth <= 0)) return;
            currentHealth = 0;
            OnPlayerDeath?.Invoke();
        }
    }
}