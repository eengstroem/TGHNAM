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

        public void GainBonus(string pickupTag)
        {
            var player = GameObject.FindWithTag("Player");
            switch (pickupTag)
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