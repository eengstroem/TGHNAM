using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraBehaviour : MonoBehaviour
    {
        public PlayerBehaviour player;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
