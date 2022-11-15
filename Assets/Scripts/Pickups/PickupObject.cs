using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    public class PickupObject : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Physics2D.IgnoreLayerCollision(7, 6, true);
            Physics2D.IgnoreLayerCollision(7, 8, true);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var objectTag = gameObject.tag;
            Destroy(gameObject);
            if (!col.gameObject.CompareTag("Player")) return;
            var playerBonuses = col.gameObject.GetComponent<PlayerBonuses>();
            playerBonuses.GainBonus(objectTag);
        }
    }
}