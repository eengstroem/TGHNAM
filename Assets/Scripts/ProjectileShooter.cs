using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectile; //reference to prefab that will be spawned
    public Transform spawnTransform; //Where projectile will spawn and it's direction/rotation
    public float cooldown; //time required before next shot being fired
    public bool shootingEnabled = true; //Are you allowed to shoot?

    private float lastShot;


    private void Awake()
    {
        lastShot = Time.time; //Time object not accessible in constructor or initializer
    }
    // Update is called once per frame
    void Update()
    {
        if (enabled && (Time.time >= lastShot + cooldown) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile, spawnTransform.position, spawnTransform.rotation);
        }
    }
}
