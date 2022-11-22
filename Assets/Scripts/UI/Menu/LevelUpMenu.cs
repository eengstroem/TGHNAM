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

        //Level up/upgrade buttons
        public Button levelUpButton1;
        public Button levelUpButton2;
        public Button levelUpButton3;
        
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

        void Start()
        {
            levelUpButton1.onClick.AddListener(UpgradeFireRate);
            levelUpButton2.onClick.AddListener(UpgradeDamage);
            levelUpButton3.onClick.AddListener(UpgradeProjectiles);
        }

        void UpgradeFireRate()
        {
            playerStats.fireRate++;
            ResumeLevel();
        }
        
        void UpgradeDamage()
        {
            playerStats.damage++;
            ResumeLevel();
        }
        
        void UpgradeProjectiles()
        {
            playerStats.numProjectiles = playerStats.numProjectiles + 2;
            ResumeLevel();
        }
        
    }
}