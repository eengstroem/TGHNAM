using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float movementSpeed = 5f;
        public Rigidbody2D rb;
        public Animator animator;

        private Vector2 movement;

        // Update is called once per frame
        void Update()
        {
            // Input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            // Movement
            rb.velocity = movement.normalized * movementSpeed;
        }
    }
}