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
        
        public int damage = 25;
        public float fireRate = 0.3f;
        public int numProjectiles = 1;
        public float projectileSpeed = 30f;
        
        [SerializeField] public TextMeshProUGUI creditText;

        void Update()
        {
            creditText.text = "Mom's Credits: " + credits;
        }

        public void AddExperience(int expAmount)
        {
            exp += expAmount;
            if (exp >= expToNextLevel)
            {
                level++;
                exp -= expToNextLevel;
                expToNextLevel = (int)(expToNextLevel * 1.1f);
            }
        }

        public void AddCredits(int creditsAmount)
        {
            credits += creditsAmount;
        }
    }
}