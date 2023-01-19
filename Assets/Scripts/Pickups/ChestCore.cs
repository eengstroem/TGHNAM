using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace Assets.Scripts.Pickups
{
    public class ChestCore : MonoBehaviour
    {
        [SerializeField]
        private bool CanTakeDamage;
        private bool _dead = false;
        private Random random = new Random();
        
        public PlayerStats playerStats;
        public float healthScaler = 1.1f;
        public GameObject HealthPickup;
        public GameObject CreditCardPickup;
        [FormerlySerializedAs("Health")] public float health;
        
        // Start is called before the first frame update
        void Start()
        {
            Physics2D.IgnoreLayerCollision(6, 6, true);
            playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
            ScaleEnemies();
        }
        
        public void TakeDamage(float damageTaken)
        {
            if (CanTakeDamage)
            {
                health -= damageTaken;
                if (health <= 0 && !_dead)
                {
                    Die();
                }
            }
            else {}
        }
        
        private void Die()
        {
            _dead = true;
            if (random.NextDouble() > 0.50)
            {
                Instantiate(HealthPickup, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(CreditCardPickup, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        
        public void ScaleEnemies()
        {
            if (playerStats.level > 0)
            {
                health = playerStats.level * (healthScaler + 100);
            }
        }
    }
}