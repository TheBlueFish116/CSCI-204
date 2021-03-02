using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private float timeSinceStart;
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
        if(timeSinceStart > 8 && timeSinceStart < 19){
            anim.SetTrigger("intro");

        }else if(timeSinceStart > 19 && timeSinceStart < 20){
            anim.ResetTrigger("intro");
            anim.SetTrigger("idle");
        }
        
        timeSinceStart += Time.deltaTime;
        
    }
}
