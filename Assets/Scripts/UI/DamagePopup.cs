using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private GameObject normalDamageTextPrefab;
    [SerializeField] private GameObject criticalDamageTextPrefab;
    
    public void ShowDamage(string text, bool isCrit)
    {
        if (criticalDamageTextPrefab && normalDamageTextPrefab)
        {
            var prefab = Instantiate(isCrit ? criticalDamageTextPrefab : normalDamageTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMeshPro>().text = text;
        }
    }
}
