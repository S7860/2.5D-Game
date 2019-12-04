using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float Speed = 200f;
  Rigidbody rb;
  Animator anim;

  bool facingRight;



  Vector3 characterScale;
  float characterScaleX;

  void Start () {
    rb = GetComponent<Rigidbody>();
    anim = GetComponent<Animator>();

    facingRight = true;

    characterScale = transform.localScale;
    characterScaleX = characterScale.x;
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

    if (horizontal > 0 && !facingRight) Flips(); 
    else if (horizontal < 0 && facingRight) Flips();     
  }

  void Flips() {
    
    facingRight = !facingRight;
    Vector3 theScale = transform.localScale;
    theScale.z *= -1;
    transform.localScale = theScale;
    
  } 

}
