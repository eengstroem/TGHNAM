using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemyPathing : MonoBehaviour
    {
        private GameObject player;
        public float movementSpeed = 5f;
        public Rigidbody2D rb;

        void Awake()
        {
            player = GameObject.FindWithTag("Player");
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var transformPos = transform.position; 
            var direction = (player.transform.position - transformPos).normalized;
            rb.velocity = direction * movementSpeed;
        }
    }
}
