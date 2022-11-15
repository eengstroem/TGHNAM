using System.Collections;
using UnityEngine;

public class FlashRed : MonoBehaviour
{
    public SpriteRenderer sprite;
    
    public IEnumerator TakeDamageFlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }



}