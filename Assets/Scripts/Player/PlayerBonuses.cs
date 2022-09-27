using UnityEngine;
using TMPro;

public class PlayerBonuses : PlayerBehaviour
{
    private static int _credits = 0;

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
            default:
                break;
                
        }
    }
}
