using Assets.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LevelUpMenu : MonoBehaviour
    {
        public GameObject levelUpMenu;
        
        [SerializeField]
        public TMP_Text levelUpText;

        private PlayerStats playerStats;
        private void OnEnable()
        {
            PlayerStats.OnLevelUp += EnableLevelUpScreen;
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }

        private void OnDisable()
        {
            PlayerStats.OnLevelUp -= EnableLevelUpScreen;
            levelUpMenu.SetActive(false);
        }

        public void EnableLevelUpScreen()
        {
            levelUpMenu.SetActive(true);
            Time.timeScale = 0;
            levelUpText.text = "Wow! You are level: " + playerStats.level;
        }

        public void ResumeLevel()
        {
            levelUpMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}