using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraBehaviour : MonoBehaviour
    {
        public PlayerMovement player;
        private float xMin, xMax, yMin, yMax;
        private float camX, camY;
        private float camOrthSize;
        private float screenAspect;
        private float cameraRatio;
        private UnityEngine.Camera mainCamera;
        
        public Transform followTransform;
        public EdgeCollider2D mapBounds;
        // Start is called before the first frame update
        void Start()
        {
            xMin = mapBounds.bounds.min.x;
            yMin = mapBounds.bounds.min.y;
            xMax = mapBounds.bounds.max.x;
            yMax = mapBounds.bounds.max.y;
            mainCamera = GetComponent<UnityEngine.Camera>();
            camOrthSize = mainCamera.orthographicSize;
            cameraRatio = (xMax + camOrthSize) / 2.0f;
        }
        
        // // Update is called once per frame
        // void Update()
        // {
        //     transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        // }
        
        private void FixedUpdate()
        {
            camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthSize, yMax - camOrthSize);
            camX = Mathf.Clamp(followTransform.position.x, xMin + camOrthSize, xMax - camOrthSize);
            this.transform.position = new Vector3(camX, camY,
                this.transform.position.z);
        }
    }
}