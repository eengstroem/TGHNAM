using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCrawler : MonoBehaviour
{
    [SerializeField] public float _scrollspeed = 1.000001f;
    public float _acceleration = 1.000001f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Camera.main.transform.up * _scrollspeed);
        _scrollspeed += Time.deltaTime * _acceleration;
    }
}
