using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //[SerializeField] private float maxHealth, currentHealth;
    public static event Action OnPlayerDeath;
    public float maxHealth;
    public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth = currentHealth-amount;
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnPlayerDeath?.Invoke();
        }
    }
}
