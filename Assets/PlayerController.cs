using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // float speed = 2;
    // float rotSpeed = 80;
    // float gravity = 8;
    // float rot = 0f;

    // Vector3 movDir = Vector3.zero;

    // CharacterController controller;
    // Animator anim;


  	// // Use this for initialization
  	// void Start ()
    // {

  	// 	// controller = this.GetComponent<CharacterController> ();
    //   // animator = GetComponent<Animator>();
    //   // rigid =  GetComponent<Rigidbody>();
    //   controller = GetComponent<CharacterController>();
    //   anim = GetComponent<Animator>();
  	// }

  	// // Update is called once per frame
  	// void Update ()
    // {
    //   Movement();
  	// }
    // void Movement()
    // {
    //   if(controller.isGrounded)
    //   {
    //     if(Input.GetKey(KeyCode.W))
    //     {
    //       if(anim.GetBool("attacking") ==true)
    //       {
    //         return;
    //       }
    //       else if(anim.GetBool("attacking") == false)
    //       {
    //         anim.SetBool("running", true);
    //         anim.SetInteger("condition",1);
    //         movDir = new Vector3(0,0,1);
    //         movDir *= speed;
    //         movDir = transform.TransformDirection(movDir);
    //       }
    //     }
    //     if(Input.GetKeyUp(KeyCode.W))
    //     {
    //       anim.SetBool("running", false);
    //       anim.SetInteger("condition",0);
    //       movDir = new Vector3(0,0,0);
    //     }
    //   }
    //   rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
    //   transform.eulerAngles =  new Vector3 (0, rot, 0);

    //   movDir.y -= gravity * Time.deltaTime;
    //   controller.Move(movDir *Time.deltaTime);
    // }


    // void GetInput()
    // {
    //   if(controller.isGrounded)
    //   {
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //       if(anim.GetBool("running") == true)
    //       {
    //         anim.SetBool("running", false);
    //         anim.SetInteger("condition",0);
    //       }

    //       if(anim.GetBool("running") == false)
    //       {
    //         Attacking();
    //       }
    //     }
    //   }
    // }
    // void Attacking()
    // {

    //   StartCoroutine(AttackRoutine());

    // }

    // IEnumerator AttackRoutine()
    // {
    //   anim.SetBool("attacking",true);
    //   anim.SetInteger("condition", 2);
    //   yield return new WaitForSeconds(1);
    //   anim.SetInteger("condition",0);
    //   anim.SetBool("attacking",false);
    // }


    // Player movements variables
    // public float runSpeed;
    
    // Rigidbody myRB;
    // Animator myAnim;
    // // Start is called before the first frame update
    // void Start()
    // {
    //   myRB = GetComponent<Rigidbody>();
    //   myAnim = GetComponent<Animator>();
    // }
    
    // // Update is called once per frame
    // void Update()
    // {
    
    // }
    
    // void FixedUpdate()
    // {
      // This 2 code makes the player move when the button a & d or left and right is pressed
      // float move =  Input.GetAxis("Horizontal");
      // float Ver =  Input.GetAxis("Vertical");
      // this checks if the value is greater then 0.01 move right else left
      // myAnim.SetFloat("speed",Mathf.Abs(move));
      // myAnim.SetFloat("speed",Mathf.Abs(Ver));
    
      // myRB.velocity =  new Vector3(move * runSpeed, myRB.velocity.y, 0);
      // myRB.velocity =  new Vector3(Ver * runSpeed, myRB.velocity.y, 0);
      // float h = Input.GetAxis("Horizontal");
      // float v = Input.GetAxis("Vertical");
      // myAnim.SetFloat("speed",Mathf.Abs(h));
      // myAnim.SetFloat("speed",Mathf.Abs(v));
      // myRB.MovePosition(transform.position + (transform.right * h + transform.up * v) * runSpeed);

      // Vector3 Movement = new Vector3 (h, 0.0f, v);
     
      // myRB.AddForce(Movement * runSpeed);
 

    // if(Input.GetAxis("Horizontal") != 0)
    // {  
    //      GetComponent<Rigidbody>().("Horizontal") = 0;
    //  }
     
    //  else if(Input.GetAxis("Vertical") != 0)
    //  {
    //      GetComponent<Rigidbody>().("Vertical") = 0;
    //  }



    public float Speed = 200f;
    Rigidbody rb;
    Animator anim;

    void Start () {
      rb = GetComponent<Rigidbody>();
      anim = GetComponent<Animator>();

    }
  void Update () 
  {
    var vertical = Input.GetAxis("Vertical");
    var horizontal = Input.GetAxis("Horizontal");

    anim.SetFloat("speed",Mathf.Abs(vertical));
    anim.SetFloat("speed",Mathf.Abs(horizontal));

    Vector3 velocity = Vector3.zero;
    velocity += (transform.forward * horizontal ); //Move forward
    velocity += (transform.right * vertical); //Strafe
    velocity *= Speed * Time.fixedDeltaTime; //Framerate and speed adjustment
    velocity.y = rb.velocity.y;
    rb.velocity = velocity;
  }
    
}
