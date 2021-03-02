using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class playerController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private Rigidbody rb;
    private Animator anim;
    private float movementx;
    private float jump = 0;
    public float speed = 0;
    public float currentTime = 0.00f;
    bool started = false;
    bool finished = false;
    private int hurdle = 0;
    private float pressFreq = 0;
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

        //This is the same one
        if(timeSinceStart > 8 && timeSinceStart < 19){
            anim.SetTrigger("intro");

        }else if(timeSinceStart > 19 && timeSinceStart < 20){
            anim.ResetTrigger("intro");
            anim.SetTrigger("idle");
        }
        if(started){
            currentTime += Time.deltaTime;
            pressFreq += Time.deltaTime;
            if(pressFreq <= 0.13){
                movementx = 10;
            }
            else if(pressFreq <= 0.15){
                movementx = 9;
            }else if(pressFreq <= 0.16){
                movementx = 8;
            }else if(pressFreq <= 0.18){
                movementx = 7;
            }else if(pressFreq <= 0.2){
                movementx = 6;
            }else if(pressFreq <= 0.22){
                movementx = 5;
            }else if(pressFreq <= 0.24){
                movementx = 4;
            }else if(pressFreq <= 1){
                movementx = 3;
            }else if(pressFreq <= 2){
                movementx = 2;
            }else{
                movementx = 1;
            }
        }else{
            timeSinceStart += Time.deltaTime;
        }

        timeText.text = "Count: " + currentTime.ToString("0.00");

        if (anim.IsInTransition(anim.GetLayerIndex("Base Layer")))
        {
            anim.ResetTrigger("jump");

        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("jump");
            if (rb.position.y < 0.3)
            {
                jump = 10;
            }
        }
        
        if(finished){
            if(movementx > 0){
                movementx-=1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            started = true;
            anim.SetTrigger("running");
            Debug.Log(pressFreq);
            pressFreq = 0;
        }
    }

    void FixedUpdate()
    {
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
            anim.SetTrigger("finished");
            anim.ResetTrigger("running");
            finished = true;
            started = false;
        }
        if(other.gameObject.CompareTag("hurdle")){
            if(hurdle != other.gameObject.GetInstanceID()){
                currentTime += 10;
                hurdle = other.gameObject.GetInstanceID();
            }
        }
    }
}
