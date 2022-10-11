using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemyCore : MonoBehaviour
    {
        public int Damage = 10;
        public int Health = 100;
        public GameObject ExperienceOrb;

        // Start is called before the first frame update
        void Start()
        {
            Physics2D.IgnoreLayerCollision(6, 6, true);
        }

        // Update is called once per frame
        void Update()
        {
        }
    
        public void TakeDamage(int damageTaken)
        {
            Health -= damageTaken;
            if (Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
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