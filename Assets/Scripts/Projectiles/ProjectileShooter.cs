using Assets.Scripts.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class ProjectileShooter : MonoBehaviour
    {
        public GameObject projectile; //reference to prefab that will be spawned
        public bool shootingEnabled = true; //Are you allowed to shoot?
        public float lifespan = 1f;
        public UnityEngine.Camera mainCam;
        public AudioSource audioSource;
    
        private float lastShot;
    
        private void Awake()
        {
            lastShot = Time.time; //Time object not accessible in constructor or initializer
        }
    
        // Update is called once per frame
        void Update()
        {
            var playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            if (!shootingEnabled || !(Time.time >= lastShot + playerStats.fireRate) || !Input.GetMouseButton(0)) return;
            
            var mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            var relativePos = mousePos - transform.position;
            var angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            var numProjectiles = playerStats.numProjectiles;

            var angleStep = 120 / numProjectiles;
            
            for (var i = 0; i < numProjectiles; i++)
            {
                var rotation = Quaternion.Euler(0, 0, angle + 45 + angleStep * i);
                var projectileInstance = Instantiate(projectile, transform.position, rotation);
                projectileInstance.GetComponent<Projectile>().damage = playerStats.damage;
                projectileInstance.GetComponent<Projectile>().speed = playerStats.projectileSpeed;
                projectileInstance.GetComponent<Projectile>().lifespan = lifespan;
                projectileInstance.GetComponent<Projectile>().isFriendly = true;
            }
                
            audioSource.PlayOneShot(audioSource.clip);
            lastShot = Time.time;
        }
    }
}
