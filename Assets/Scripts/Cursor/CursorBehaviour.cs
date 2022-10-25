using UnityEngine;

namespace Assets.Scripts.Cursor
{
    public class CursorBehaviour : MonoBehaviour
    {

        public Texture2D crosshairTexture;
    
        // Start is called before the first frame update
        void Start()
        {
            UnityEngine.Cursor.SetCursor(crosshairTexture, new Vector2((float)crosshairTexture.width / 2, (float)crosshairTexture.height / 2), CursorMode.Auto);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
