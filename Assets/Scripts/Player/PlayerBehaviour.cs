using Unity.Mathematics;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //STATS
    public float movementSpeed; //tiles per second
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        
        transform.rotation = horizontalInput < 0 ? new Quaternion(0, 180, 0, 0) : new Quaternion(0, 0, 0, 0);
        
        transform.Translate(Vector3.right * math.abs(horizontalInput) * Time.deltaTime * movementSpeed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * movementSpeed);
    }
}
