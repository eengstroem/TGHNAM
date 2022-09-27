using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{

    public Texture2D crosshairTexture;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(crosshairTexture, new(crosshairTexture.width / 2, crosshairTexture.height / 2), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}