using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  // public float Speed = 200f;
  // Rigidbody rb;
  // Animator anim;

  // bool facingRight;
  // bool facingUp;
  // public float rotateSpeed = 3.0F;
  
  // void Start () {
  //   rb = GetComponent<Rigidbody>();
  //   anim = GetComponent<Animator>();

  //   facingRight = true;
  //   facingUp = true;
    
    
  // }
  // void Update () 
  // {
  //     var vertical = Input.GetAxis("Vertical");
  //     var horizontal = Input.GetAxis("Horizontal") ;

  //     anim.SetFloat("speed",Mathf.Abs(vertical));
  //     anim.SetFloat("speed",Mathf.Abs(horizontal));

  //     Vector3 velocity = Vector3.zero;
  //     velocity += (transform.forward * horizontal ); //Move forward
  //     velocity += (transform.right * vertical); //Strafe
  //     velocity *= Speed * Time.fixedDeltaTime; //Framerate and speed adjustment
  //     velocity.y = rb.velocity.y;
  //     rb.velocity = velocity;

  
  //     if (horizontal > 0 && !facingRight) FlipsRight(); 
  //     else if (horizontal < 0 && facingRight) FlipsRight();     
  // }
 
  // void FlipsRight() {
    
  //   facingRight = !facingRight;
  //   Vector3 theScale = transform.localScale;
  //   theScale.z *= -1;
  //   transform.localScale = theScale;
    
  // } 

    public float speed = 3.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 500.0F;
    private Vector3 moveDirection = Vector3.zero;
    Animator anim;
    // Use this for initialization
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            var vertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            anim.SetFloat("speed",Mathf.Abs(vertical));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Rotate Player
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

    }
}
