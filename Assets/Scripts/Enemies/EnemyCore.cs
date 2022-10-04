using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public int damage = 10;
    public int health = 100;
    public GameObject experienceOrb;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Instantiate(experienceOrb, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
