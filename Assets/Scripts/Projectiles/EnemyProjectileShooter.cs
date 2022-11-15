using Assets.Scripts.Enemies;
using Assets.Scripts.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class EnemyProjectileShooter : MonoBehaviour
    {
        public GameObject projectile; //reference to prefab that will be spawned
        public bool shootingEnabled = true; //Are you allowed to shoot?
        public AudioSource audioSource;
        private float lastShot;
        private EnemyCore enemyStats;
        private GameObject player;
        
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            lastShot = Time.time; //Time object not accessible in constructor or initializer
            enemyStats = gameObject.GetComponent<EnemyCore>();
        }
    
        // Update is called once per frame
        void Update()
        {
            if (!shootingEnabled || !(Time.time >= lastShot + enemyStats.fireRate)) return;
            var playerPos = player.transform.position;
            var relativePos = playerPos - transform.position;
            var angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            var numProjectiles = enemyStats.numProjectiles;

            var angleStep = 120 / numProjectiles;
            
            for (var i = 0; i < numProjectiles; i++)
            {
                var rotation = Quaternion.Euler(0, 0, angle + 45 + angleStep * i);
                var projectileInstance = Instantiate(projectile, transform.position, rotation);
                projectileInstance.GetComponent<Projectile>().damage = enemyStats.damage;
                projectileInstance.GetComponent<Projectile>().speed = enemyStats.projectileSpeed;
                projectileInstance.GetComponent<Projectile>().isFriendly = false;
            }
                
            audioSource.PlayOneShot(audioSource.clip);
            lastShot = Time.time;
        }
    }
}
