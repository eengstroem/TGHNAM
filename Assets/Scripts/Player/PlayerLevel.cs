using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int _level = 0;
    private int _exp = 0;
    private int _expToNextLevel = 10;

    public void AddExperience(int expAmount)
    {
        _exp += expAmount;
        if (_exp >= _expToNextLevel)
        {
            _level++;
            _exp -= _expToNextLevel;
        }
    }
    
}
