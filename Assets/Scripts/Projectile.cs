using UnityEngine;


//[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

    public float speed = 10f;   // projectile's speed
    public float lifespan = 3f; // projectile's lifespan (in seconds)

    //private Rigidbody2D m_Rigid;


    void Awake()
    {
      //  m_Rigid = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Message that is called before the first frame update
    /// </summary>
    void Start()
    {
        //m_Rigid.AddForce(m_Rigid.transform.forward * speed);
        Debug.Log("X: " + transform.position.x);
        Debug.Log("Y: " + transform.position.y);
        Debug.Log("Z: " + transform.position.z);
       // Debug.Log("Velocity: " + m_Rigid.velocity);
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        var forward = -transform.up;
        forward.z = 0;
        transform.position += forward * speed * Time.deltaTime;
        Debug.Log("X: " + transform.position.x);
        Debug.Log("Y: " + transform.position.y);
        Debug.Log("Z: " + transform.position.z);
        //Debug.Log("Velocity: " + m_Rigid.velocity);
    }
}