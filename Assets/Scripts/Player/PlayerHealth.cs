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
        public FlashRed flashRed;

        public float collisionInvulnerabilityTime, projectileInvulnerabilityTime, miscInvulnerabilityTime = 0.1f;
        private float _collisionDamageTime, _projectileDamageTime, _miscDamageTime;
        
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
        }

        void Update()
        {
            if(currentHealth < maxHealth)
            {
                currentHealth += healthRegen * Time.deltaTime;
            }
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
                    if (now <= _collisionDamageTime + collisionInvulnerabilityTime)
                        return;
                    break;
                case EDamageType.PROJECTILE:
                    if (now <= _projectileDamageTime + projectileInvulnerabilityTime)
                        return;
                    break;
                case EDamageType.MISC:
                    if (now <= _miscDamageTime + miscInvulnerabilityTime)
                        return;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            _collisionDamageTime = now;

            
            currentHealth -= amount;
            StartCoroutine(flashRed.TakeDamageFlashRed());

            if (!(currentHealth <= 0)) return;
            currentHealth = 0;
            OnPlayerDeath?.Invoke();
        }
    }
}