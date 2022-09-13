using System.Collections;
using System.Collections.Generic;
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * movementSpeed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * movementSpeed * verticalInput * Time.deltaTime);

    }
}
