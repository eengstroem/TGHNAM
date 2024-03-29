using Assets.Scripts.Enemies;
using Assets.Scripts.Pickups;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 10f;   // modified speed of the projectile
        public float lifespan = 1f; // projectile's lifespan (in seconds)
        public Rigidbody2D m_Rigid;
        public float damage = 1;   // damage dealt to the enemy
        public bool isFriendly;
        private const float BaseSpeed = 10f; // base speed of the projectile

        /// <summary>
        /// Message that is called before the first frame update
        /// </summary>
        void Start()
        {
            Physics2D.IgnoreLayerCollision(0, 8, false);
            Physics2D.IgnoreLayerCollision(8, 8, true);

            var forward = -transform.up;
            forward.z = 0;
        
            m_Rigid.AddForce(BaseSpeed * speed * forward);
        
            Destroy(gameObject, lifespan);
        }
        
        void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Projectile":
                    return;
                case "Player":
                    if (!isFriendly)
                    {
                        collision.gameObject.GetComponent<PlayerHealth>().TakeDamage((int)damage, PlayerHealth.EDamageType.PROJECTILE);
                        Destroy(gameObject);
                    }
                    return;
                case "Enemy":
                    if (isFriendly)
                    {
                        collision.gameObject.GetComponent<EnemyCore>().TakeDamage(damage);
                        Destroy(gameObject);
                    }
                    return;
                case "LootChest":
                    if (isFriendly)
                    {
                        collision.gameObject.GetComponent<ChestCore>().TakeDamage(damage);
                        Destroy(gameObject);
                    }
                    return;
                default:
                    Destroy(gameObject);
                    break;
            }
        }
    }
}