using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movements variables
    public float runSpeed;

    Rigidbody myRB;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
      myRB = GetComponent<Rigidbody>();
      myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate()
    {
      // This 2 code makes the player move when the button a & d or left and right is pressed
      float move =  Input.GetAxis("Horizontal");
      // this checks if the value is greater then 0.01 move right else left
      myAnim.SetFloat("speed",Mathf.Abs(move));

      myRB.velocity =  new Vector3(move * runSpeed, myRB.velocity.y, 0);
    }
}
