using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        public static event Action OnLevelUp;
        public int level = 0;
        public float exp = 0;
        public float expToNextLevel = 10;
        public float credits = 0;
        
        public float damage = 25f;
        public float fireRate = 0.4f;
        public int numProjectiles = 1;
        public float projectileSpeed = 30f;
        public float critChance = 0.05f; 
        public float critMultiplier = 2f;
        
        [SerializeField] public TextMeshProUGUI creditText;
        [SerializeField] public TextMeshProUGUI levelText;

        void Update()
        {
            creditText.text = "Mom's Credits: " + credits;
            levelText.text = "Level: " + level + " (" + exp + "/" + expToNextLevel + ")";
        }

        public void AddExperience(int expAmount)
        {
            exp += expAmount;
            if (!(exp >= expToNextLevel)) return;
            
            level++;
            exp -= expToNextLevel;
            expToNextLevel = (int)(expToNextLevel * 1.1f);
            OnLevelUp?.Invoke();
        }

        public void AddCredits(int creditsAmount)
        {
            credits += creditsAmount;
        }
    }
}