using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField] private float maxHealth, currentHealth;
    public static event Action OnPlayerDeath;
    public float maxHealth;
    public float currentHealth;

    public float collisionInvulnerabilityTime, projectileInvulnerabilityTime, miscInvulnerabilityTime = 0.1f;
    private float collisionDamageTime, projectileDamageTime, miscDamageTime;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public enum EDamageType
    {
        COLLISION,
        PROJECTILE,
        MISC
    }

    public void TakeDamage(int amount, EDamageType type)
    {
        float now = Time.time;
        
        switch (type) { 
            case EDamageType.COLLISION:
                if (now <= collisionDamageTime + collisionInvulnerabilityTime)
                {
                    return;
                } else
                {
                    collisionDamageTime = now;
                }
                break;
            case EDamageType.PROJECTILE:
                if (now <= projectileDamageTime + projectileInvulnerabilityTime)
                {
                    return;
                }
                else
                {
                    collisionDamageTime = now;
                }
                break;
            case EDamageType.MISC:
                if (now <= miscDamageTime + miscInvulnerabilityTime)
                {
                    return;
                }
                else
                {
                    collisionDamageTime = now;
                }
                break;
        }

        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnPlayerDeath?.Invoke();
        }
    }
}
