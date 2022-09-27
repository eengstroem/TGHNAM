using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectile; //reference to prefab that will be spawned
    public Transform spawnTransform; //Where projectile will spawn and it's direction/rotation
    public float cooldown = 100000; //time required before next shot being fired
    public bool shootingEnabled = true; //Are you allowed to shoot?
    public Camera mainCam;

    private float lastShot;


    private void Awake()
    {
        lastShot = Time.time; //Time object not accessible in constructor or initializer
    }
    // Update is called once per frame
    void Update()
    {
        if (shootingEnabled && Time.time >= lastShot + cooldown && Input.GetMouseButton(0))
        {
            Debug.DrawLine(Input.mousePosition, transform.position);
            var mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 relativePos = mousePos - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.Euler(0,0, angle+90);


            Instantiate(projectile, transform.position, rotation);
            lastShot = Time.time;
        }
    }
}
