using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPathing : MonoBehaviour
{
    private GameObject player;
    public float movementSpeed = 0.5F;

    private void getPlayerPosition()
    {

    }

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Debug.Log(player);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }
}
