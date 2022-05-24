using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] float playerSpeed;
    [SerializeField] Animator playerAnimator; 
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

        playerRigidBody.velocity = new Vector2(horizontalInput, verticalInput) * playerSpeed;
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.

        playerAnimator.SetFloat("movementX", playerRigidBody.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody.velocity.y);
        //Animator Movement Control
        if (horizontalInput == 1 || horizontalInput == -1 || verticalInput == 1 || verticalInput == -1)
        {
            playerAnimator.SetFloat("lastX", horizontalInput);
            playerAnimator.SetFloat("lastY", verticalInput);
        }
       //Animator Idling Control
    }
}
