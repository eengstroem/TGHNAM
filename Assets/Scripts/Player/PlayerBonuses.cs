using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerBonuses : MonoBehaviour
    {
        private static int _credits = 0;
        private static int _experience = 0;

        [SerializeField] public TextMeshProUGUI creditText;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            creditText.text = "Mom's Credits: " + _credits;
        }

        public void GainBonus(GameObject pickup)
        {
            switch (pickup.tag)
            {
                case "CreditCard":
                    _credits++;
                    return;
                case "Experience":
                    _experience++;
                    return;
                default:
                    break;
                
            }
        }
    }
}
