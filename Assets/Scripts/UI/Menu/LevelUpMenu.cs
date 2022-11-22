using Assets.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LevelUpMenu : MonoBehaviour
    {
        public GameObject levelUpMenu;
        
        [FormerlySerializedAs("levelUpText")] [SerializeField]
        public TMP_Text levelUpText1;
        [SerializeField]
        public TMP_Text levelUpText2;
        [SerializeField]
        public TMP_Text levelUpText3;
        [SerializeField]
        public TMP_Text levelUpText4;
        [SerializeField]
        public TMP_Text levelUpText5;
        [SerializeField]
        public TMP_Text levelUpText6;

        //Level up/upgrade buttons
        public Button levelUpButton1;
        public Button levelUpButton2;
        public Button levelUpButton3;
        public Button levelUpButton4;
        public Button levelUpButton5;
        public Button levelUpButton6;

        
        private PlayerStats playerStats;
        private void OnEnable()
        {
            PlayerStats.OnLevelUp += EnableLevelUpScreen;
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            levelUpText1.text = "Upgrade fire rate";
            levelUpText2.text = "Upgrade damage";
            levelUpText3.text = "Upgrade projectiles";
            levelUpText4.text = "Upgrade bullet speed";
            levelUpText5.text = "Upgrade crit multiplier";
            levelUpText6.text = "Upgrade crit chance";
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
            levelUpButton4.onClick.AddListener(UpgradeCritMultiplier);
            levelUpButton5.onClick.AddListener(UpgradeProjectileSpeed);
            levelUpButton6.onClick.AddListener(UpgradeCritChance);
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
        
        void UpgradeProjectileSpeed()
        {
            playerStats.projectileSpeed = playerStats.projectileSpeed + 5;
            ResumeLevel();
        }
        
        void UpgradeCritChance()
        {
            playerStats.critChance = playerStats.critChance + 0.01f;
            ResumeLevel();
        }
        
        void UpgradeCritMultiplier()
        {
            playerStats.critMultiplier = playerStats.critMultiplier + 0.05f;
            ResumeLevel();
        }
        
    }
}