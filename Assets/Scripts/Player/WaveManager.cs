using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Player
{
    public class WaveManager : MonoBehaviour
    {
        // Comment out for now. Making changes to spawning
        // public GameObject enemySpawnerPrefab;
        //
        // private List<GameObject> spawners = new ();
        // Renderer m_Renderer;
        // // Use this for initialization
        //
        // // Start is called before the first frame update
        // void Start()
        // {
        //     m_Renderer = GetComponent<Renderer>();
        //     // Create enemy spawners around the player, outside the camera field of view
        //     Random.InitState((int)DateTime.Now.Ticks);
        //     var playerPos = GameObject.FindWithTag("Player").transform.position;
        //     var spawner = Instantiate(enemySpawnerPrefab, new Vector3(playerPos.x + Random.Range(-5, 5), playerPos.y + Random.Range(-5, 5), 0), Quaternion.identity);
        //     var spawner2 = Instantiate(enemySpawnerPrefab, new Vector3(playerPos.x + Random.Range(-5, 5), playerPos.y + Random.Range(-5, 5), 0), Quaternion.identity);
        //     var spawner3 = Instantiate(enemySpawnerPrefab, new Vector3(playerPos.x + Random.Range(-5, 5), playerPos.y + Random.Range(-5, 5), 0), Quaternion.identity);
        //     var spawner4 = Instantiate(enemySpawnerPrefab, new Vector3(playerPos.x + Random.Range(-5, 5), playerPos.y + Random.Range(-5, 5), 0), Quaternion.identity);
        //     spawners.Add(spawner);        
        //     spawners.Add(spawner2);
        //     spawners.Add(spawner3);
        //     spawners.Add(spawner4);
        // }
        //
        // // Update is called once per frame
        // void Update()
        // {
        //     if (!m_Renderer.isVisible)
        //     {
        //         var playerPos = GameObject.FindWithTag("Player").transform.position;
        //         spawners[0].transform.position = new Vector3(playerPos.x + 6, playerPos.y + 6, 0);
        //         spawners[1].transform.position = new Vector3(playerPos.x - 5, playerPos.y - 5, 0);
        //         spawners[2].transform.position = new Vector3(playerPos.x + 5, playerPos.y - 5, 0);
        //         spawners[3].transform.position = new Vector3(playerPos.x - 5, playerPos.y + 5, 0);
        //     }
        // }
    }
}