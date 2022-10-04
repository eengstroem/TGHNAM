using System.Linq;
using UnityEngine;


public class EnemyPathing : MonoBehaviour
{
    private GameObject player;
    public float movementSpeed = 0.5F;
    public CapsuleCollider2D m_Collider;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Debug.Log(player);
    }

    // Start is called before the first frame update
    void Start()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        enemies.ForEach(x => Physics2D.IgnoreCollision(x.GetComponent<Collider2D>(), m_Collider));
    }

    // Update is called once per frame
    void Update()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }
}
