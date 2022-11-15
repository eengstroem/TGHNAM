using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour
{
    public GameObject _prop;
    private static WebCamTexture backCam;
    // Start is called before the first frame update
    void Start()
    {
        if (backCam == null)
            backCam = new WebCamTexture();
        
        if (!backCam.isPlaying)
        {
            backCam.Play();
        }

        _prop.GetComponent<Image>().material.mainTexture = backCam;
    }
}
