using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{

    public float speed = 10f;   // projectile's speed
    public float lifespan = 3f; // projectile's lifespan (in seconds)

    private Rigidbody m_Rigidbody;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Message that is called before the first frame update
    /// </summary>
    void Start()
    {
        m_Rigidbody.AddForce(m_Rigidbody.transform.forward * speed);
        Destroy(gameObject, lifespan);
    }
}