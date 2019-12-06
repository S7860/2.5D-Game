

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    void Awake ()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask ("Floor");

        // Set up references.
        anim = GetComponent <Animator> ();
        playerRigidbody = GetComponent <Rigidbody> ();
    }


    void FixedUpdate ()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");

        // Move the player around the scene.
        Move (h, v);

        // Turn the player to face the mouse cursor.
        Turning ();

        // Animate the player.
        Animating (h, v);
    }

    void Move (float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set (h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition (transform.position + movement);
    }

    void Turning ()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation (newRotation);
        }
    }

    void Animating (float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool ("IsWalking", walking);
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//   // public float Speed = 200f;
//   // Rigidbody rb;
//   // Animator anim;

//   // bool facingRight;
//   // bool facingUp;
//   // public float rotateSpeed = 3.0F;

//   // void Start () {
//   //   rb = GetComponent<Rigidbody>();
//   //   anim = GetComponent<Animator>();

//   //   facingRight = true;
//   //   facingUp = true;


//   // }
//   // void Update ()
//   // {
//   //     var vertical = Input.GetAxis("Vertical");
//   //     var horizontal = Input.GetAxis("Horizontal") ;

//   //     anim.SetFloat("speed",Mathf.Abs(vertical));
//   //     anim.SetFloat("speed",Mathf.Abs(horizontal));

//   //     Vector3 velocity = Vector3.zero;
//   //     velocity += (transform.forward * horizontal ); //Move forward
//   //     velocity += (transform.right * vertical); //Strafe
//   //     velocity *= Speed * Time.fixedDeltaTime; //Framerate and speed adjustment
//   //     velocity.y = rb.velocity.y;
//   //     rb.velocity = velocity;


//   //     if (horizontal > 0 && !facingRight) FlipsRight();
//   //     else if (horizontal < 0 && facingRight) FlipsRight();
//   // }

//   // void FlipsRight() {

//   //   facingRight = !facingRight;
//   //   Vector3 theScale = transform.localScale;
//   //   theScale.z *= -1;
//   //   transform.localScale = theScale;

//   // }

//     public float speed = 3.0F;
//     public float jumpSpeed = 8.0F;
//     public float gravity = 20.0F;
//     public float rotateSpeed = 100.0F;
//     private Vector3 moveDirection = Vector3.zero;
//     Animator anim;

//     bool running;
//     // Use this for initialization
//     void Start()
//     {
//       anim = GetComponent<Animator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         CharacterController controller = GetComponent<CharacterController>();
//         var vertical = Input.GetAxis("Vertical");
//         var horizontal = Input.GetAxis("Horizontal");

//         if (controller.isGrounded)
//         {
//             moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
//             anim.SetFloat("speed",Mathf.Abs(vertical));
//             moveDirection = transform.TransformDirection(moveDirection);
//             moveDirection *= speed;
//             if (Input.GetButton("Jump"))
//                 moveDirection.y = jumpSpeed;

//             if (Mathf.Abs(horizontal) > 0)
//             { 
//               running = true;
//             }
//         }
//         moveDirection.y -= gravity * Time.deltaTime;
//         controller.Move(moveDirection * Time.deltaTime);

//         //Rotate Player
//         transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

//     }
//     public bool getRunning()
//     {
//       return (running);
//     }
// }
