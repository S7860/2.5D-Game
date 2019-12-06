using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    public float damage;
    public float knockBack;
    public float knockBackRadius;
    public float meleeRate;

    float nextMelee;

    int shootableMask;

    Animator anim;
    PlayerController myPc;
    // Start is called before the first frame update
    void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        anim = transform.root.GetComponent<Animator>();
        myPc = transform.root.GetComponent<PlayerController>();
        nextMelee = 0f;
    }
    void FixedUpdate()
    {
        float melee =  Input.GetAxis("Fire2");

        if (melee > 0 && nextMelee < Time.time && !(myPc.getRunning()))
        {
            anim.SetTrigger("spearMelee");
            nextMelee = Time.time + meleeRate;

            Collider [ ] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);

        }
    }
}
