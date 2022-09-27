using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerBonuses : MonoBehaviour
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
