using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class RandomSpawner : MonoBehaviour
    {
        [SerializeField]
        public GameObject enemyPrefabs;

        [SerializeField] private const float SpawnInterval = 4.0f;
        Renderer m_Renderer;
        void Start()
        {
            StartCoroutine(SpawnEnemy(SpawnInterval, enemyPrefabs));
            m_Renderer = GetComponent<Renderer>();
        }

        private IEnumerator SpawnEnemy(float interval, GameObject enemy)
        {
            yield return new WaitForSeconds(interval);  
            // Silly random settings to spawn at random points
            if (!m_Renderer.isVisible)
            {
            var newEnemy = Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, 0),
                Quaternion.identity);


                StartCoroutine(SpawnEnemy(interval, enemy));
            }
        }
    }
}
