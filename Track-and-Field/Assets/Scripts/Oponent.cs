using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private float movementx;
    private float jump = 0;
    public float speed = 0;
    bool started = false;
    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            started = true;
        }
        if(finished){
            if(movementx > 0){
                movementx-=1;
            }
        }else if(started){
            anim.SetTrigger("Running");
            movementx = 8;
        }
    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(movementx, -1 + jump, 0.0f);
        if (jump != 0)
        {
            jump -= 1;
        }
        rb.velocity = movement;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Finish"))
        {
            anim.SetTrigger("Idle");
            anim.ResetTrigger("Running");
            finished = true;
            started = false;
        }
        else if(other.gameObject.CompareTag("oponentJump")){
            anim.SetTrigger("Jump");
            jump = 10;
        }
    }
}
