using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace Assets.Scripts.Enemies
{
    public class EnemyCore : MonoBehaviour
    {
        [SerializeField]
        private bool CanTakeDamage;
        private bool _dead = false;
        public GameObject ExperienceOrb;
        public DamagePopup damagePopup;
        private Random random = new Random();
        public FlashRed flashRed;

        public PlayerStats playerStats;
        public EnemyPathing enemyPathing;
        
        //Enemy shooting stats and stuff
        public int damage;
        [FormerlySerializedAs("Health")] public float health;
        public float fireRate;
        public float numProjectiles;
        public float projectileSpeed;

        public float healthScaler = 1.5f;
        public float damageScaler = 100f;
        public float movementSpeedScaler = 2f;
        
        // Start is called before the first frame update
        void Start()
        {
            Physics2D.IgnoreLayerCollision(6, 6, true);
            playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
            enemyPathing = GameObject.FindWithTag("Enemy").GetComponent<EnemyPathing>();
            ScaleEnemies();
        }

        // Update is called once per frame
        void Update()
        {
        }
    
        public void TakeDamage(float damageTaken)
        {
            if (CanTakeDamage)
            {
                var isCrit = random.NextDouble() < playerStats.critChance;

                damageTaken = isCrit ? damageTaken * playerStats.critMultiplier : damageTaken;
                
                StartCoroutine(flashRed.TakeDamageFlashRed());
                damagePopup.ShowDamage(damageTaken.ToString(), isCrit);
                health -= damageTaken;
                if (health <= 0 && !_dead)
                {
                    Die();
                }
            }
            else {} //Empty because CanTakeDamage should not apply to stuff like the firewall
        }

        private void Die()
        {
            _dead = true;
            Instantiate(ExperienceOrb, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                collision.gameObject
                    .GetComponent<PlayerHealth>()
                    .TakeDamage(damage, PlayerHealth.EDamageType.COLLISION);
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                collision.gameObject
                    .GetComponent<PlayerHealth>()
                    .TakeDamage(damage, PlayerHealth.EDamageType.COLLISION);
        }

        public void ScaleEnemies()
        {
            if (playerStats.level > 0)
            {
                health = playerStats.level * (healthScaler + 100);
                damage = (int) (playerStats.level * damageScaler);
            }
        }
    }
}