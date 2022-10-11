using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerBonuses : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void GainBonus(GameObject pickup)
        {
            var player = GameObject.FindWithTag("Player");
            switch (pickup.tag)
            {
                case "CreditCard":
                    player.GetComponent<PlayerStats>().AddCredits(1);
                    return;
                case "Experience":
                    player.GetComponent<PlayerStats>().AddExperience(1);
                    return;
                default:
                    break;
            }
        }
    }
}