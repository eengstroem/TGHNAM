using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 20f;   // modified speed of the projectile
        public float lifespan = 3f; // projectile's lifespan (in seconds)
        public Rigidbody2D m_Rigid;

        private const float BaseSpeed = 10f; // base speed of the projectile

        /// <summary>
        /// Message that is called before the first frame update
        /// </summary>
        void Start()
        {
            Physics2D.IgnoreLayerCollision(0, 8, true);
            Physics2D.IgnoreLayerCollision(8, 8, true);

            var forward = -transform.up;
            forward.z = 0;
        
            m_Rigid.AddForce(BaseSpeed * speed * forward);
        
            Destroy(gameObject, lifespan);
        }

        void Update()
        {
            //transform.position += forward * speed * Time.deltaTime;
            Debug.Log("Velocity: " + m_Rigid.velocity);
            Debug.Log("Velocity magnitude: " + m_Rigid.velocity.magnitude);
        }
    
        void OnCollisionEnter2D(Collision2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Projectile":
                    return;
                case "Player":
                    return;
                case "Enemy":
                    collision.gameObject.GetComponent<EnemyCore>().TakeDamage(25);
                    Destroy(gameObject);
                    return;
                default:
                    Debug.Log("Collision");
                    Destroy(gameObject);
                    break;
            }
        }
    }
}