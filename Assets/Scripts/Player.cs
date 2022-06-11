using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] float playerSpeed;
    [SerializeField] Animator playerAnimator;

    public string pointOfAppearance;

    private Vector2 bottomLeftEdge;
    private Vector2 topRightEdge;

    [SerializeField] Tilemap backgroundBounds;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        bottomLeftEdge = backgroundBounds.localBounds.min + new Vector3(1f, 1f, 0f);
        topRightEdge = backgroundBounds.localBounds.max + new Vector3(-1f, -1f , 0f);
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

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x,bottomLeftEdge.x,topRightEdge.x),
            Mathf.Clamp(transform.position.y,bottomLeftEdge.y,topRightEdge.y)
        );
    }
}
