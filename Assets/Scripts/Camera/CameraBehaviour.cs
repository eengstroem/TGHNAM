using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraBehaviour : MonoBehaviour
    {
        public PlayerMovement player;
        private float _xMin, _xMax, _yMin, _yMax;
        private float _camX, _camY;
        private float _camOrthSize;
        private float _screenAspect;
        private UnityEngine.Camera _mainCamera;
        
        public Transform followTransform;
        public EdgeCollider2D mapBounds;
        // Start is called before the first frame update
        void Start()
        {
            _xMin = mapBounds.bounds.min.x;
            _yMin = mapBounds.bounds.min.y;
            _xMax = mapBounds.bounds.max.x;
            _yMax = mapBounds.bounds.max.y;
            _mainCamera = GetComponent<UnityEngine.Camera>();
            _camOrthSize = _mainCamera.orthographicSize;
        }
        
        // // Update is called once per frame
        // void Update()
        // {
        //     transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        // }
        
        private void FixedUpdate()
        {
            _camY = Mathf.Clamp(followTransform.position.y, _yMin + _camOrthSize, _yMax - _camOrthSize);
            _camX = Mathf.Clamp(followTransform.position.x, _xMin + _camOrthSize, _xMax - _camOrthSize);
            transform.position = new Vector3(_camX, _camY, transform.position.z);
        }
    }
}