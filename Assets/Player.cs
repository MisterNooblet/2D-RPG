using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxisRaw("Vertical");
        //Get the value of the Vertical input axis.

        playerRigidBody.transform.Translate(new Vector2(horizontalInput, verticalInput) * playerSpeed * Time.deltaTime);
   
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
    }
}
