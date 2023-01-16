using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerBonuses : MonoBehaviour
    {

        private PlayerHealth playerHealth;
        private GameObject player;
        
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void GainBonus(string pickupTag)
        {
            switch (pickupTag)
            {
                case "CreditCard":
                    player.GetComponent<PlayerStats>().AddCredits(1);
                    return;
                case "Experience":
                    player.GetComponent<PlayerStats>().AddExperience(1);
                    return;
                case "Health":
                    if (playerHealth.currentHealth + 20 > playerHealth.maxHealth)
                        playerHealth.currentHealth = playerHealth.maxHealth;
                    else
                        playerHealth.currentHealth += 20;
                    return;
                default:
                    break;
            }
        }
    }
}