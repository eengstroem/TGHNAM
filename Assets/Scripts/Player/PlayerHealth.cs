using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(int amount)
    {
        currentHealth = currentHealth-amount;
        
        if (currentHealth <= 0)
        {
            //Become dead
        }
    }
}
