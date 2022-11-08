using Assets.Scripts.Player;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Enemies
{
    public class EnemyCore : MonoBehaviour
    {
        private bool _dead = false;
        public int Damage = 10;
        public float Health = 100f;
        public GameObject ExperienceOrb;
        public DamagePopup damagePopup;
        private Random random = new Random();

        // Start is called before the first frame update
        void Start()
        {
            Physics2D.IgnoreLayerCollision(6, 6, true);
        }

        // Update is called once per frame
        void Update()
        {
        }
    
        public void TakeDamage(float damageTaken)
        {
            var player = GameObject.FindWithTag("Player");
            var isCrit = random.NextDouble() < player.GetComponent<PlayerStats>().critChance;
            
            damageTaken = isCrit ? damageTaken * 2 : damageTaken;
            
            damagePopup.ShowDamage(damageTaken.ToString(), isCrit);
            Health -= damageTaken;
            if (Health <= 0 && !_dead)
            {
                Die();
            }
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
                    .TakeDamage(Damage, PlayerHealth.EDamageType.COLLISION);
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                collision.gameObject
                    .GetComponent<PlayerHealth>()
                    .TakeDamage(Damage, PlayerHealth.EDamageType.COLLISION);
        }
    }
}