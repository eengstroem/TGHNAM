using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDamageText : MonoBehaviour
{
    [SerializeField] private float seconds = 0.4f;
    void Start()
    {
        Destroy(gameObject, seconds);
    }
}
