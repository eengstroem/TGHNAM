using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float baseSpeed = 10f; // base speed of the projectile
    
    public float speed = 20f;   // modified speed of the projectile
    public float lifespan = 3f; // projectile's lifespan (in seconds)
    
    public Rigidbody2D m_Rigid;
    public CapsuleCollider2D m_Collider;
    
    /// <summary>
    /// Message that is called before the first frame update
    /// </summary>
    void Start()
    {
        Physics2D.IgnoreCollision(GameObject.FindWithTag("Player").GetComponent<Collider2D>(), m_Collider);
        var projectiles = GameObject.FindGameObjectsWithTag("Projectile").ToList();
        projectiles.ForEach(x => Physics2D.IgnoreCollision(x.GetComponent<Collider2D>(), m_Collider));

        var forward = -transform.up;
        forward.z = 0;
        
        m_Rigid.AddForce(baseSpeed * speed * forward);
        
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