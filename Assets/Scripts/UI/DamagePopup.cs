using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private GameObject damageTextPrefab;
    
    public void ShowDamage(string text)
    {
        if (damageTextPrefab)
        {
            GameObject prefab = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMeshPro>().text = text;
        }
    }
}
