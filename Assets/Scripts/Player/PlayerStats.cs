using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        public int level = 0;
        public float exp = 0;
        public float expToNextLevel = 10;
        public float credits = 0;
        
        public float damage = 25f;
        public float fireRate = 0.3f;
        public int numProjectiles = 1;
        public float projectileSpeed = 30f;
        
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
        }

        public void AddCredits(int creditsAmount)
        {
            credits += creditsAmount;
        }
    }
}