using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class FillStatusBars : MonoBehaviour
    {
        public GameObject player;
        private Slider _healthSlider;      
        private Slider _experienceSlider;
        private PlayerHealth _playerHealth;
        private PlayerStats _playerExperience;
        private 

        // Start is called before the first frame update
        void Awake()
        {
            _healthSlider = GameObject.FindWithTag("PlayerHealthBar").GetComponent<Slider>();
            _experienceSlider = GameObject.FindWithTag("PlayerExperienceBar").GetComponent<Slider>();
            _playerHealth = player.GetComponent<PlayerHealth>();
            _playerExperience = player.GetComponent<PlayerStats>();
        }

        // Update is called once per frame
        void Update()
        {
            var healthFill = _playerHealth.currentHealth / _playerHealth.maxHealth;
            var experienceFill = _playerExperience.exp / _playerExperience.expToNextLevel;
            _healthSlider.value = healthFill;
            _experienceSlider.value = experienceFill;
        }
    }
}