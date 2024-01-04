using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(0, 1)]
    public float speed;
    public int lastdir;
    public bool move = false;
    private Animator AN;

    public Rigidbody RB;

    public bool wasLanding;
    private Vector3 lookVector;
    private Action delayrunAction;
    public int delayrun;
    private bool jumping;
    private bool goLanding;
    public int landingcount;
    private bool death;
    private int deathdelay;

    void Start()
    {
        AN = GetComponentInChildren<Animator>();
        RB = GetComponent<Rigidbody>();
        wasLanding = false;
        lastdir = 1;
        lookVector = Vector3.forward;
        delayrunAction = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(jumping)
        if (--delayrun <= 0)
        {
            if (delayrunAction != null)
            {
                delayrunAction();
                delayrunAction = null;
            }
        }
        else
            print(delayrun);
        //transform.LookAt(lookVector);
        if (move)
            transform.position += transform.forward * speed;
            //ansform.Translate(transform.forward * speed);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (lastdir != 1)
            {
                //AN.SetBool("Turn", true);
                lastdir = 1;
                transform.Rotate(transform.up, 180);
            }

            move = true;
            AN.SetBool("Walking", true);
        }
        else
        {


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                
                if (lastdir != 2)
                {
                    transform.Rotate(transform.up, 180);
                    lastdir = 2;
                }
                move = true;
                AN.SetBool("Walking", true);
            }
            else
            {
                AN.SetBool("Walking", false);
                move = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            jumping = true;
            print("JUMP");
            AN.SetBool("Jump", true);
            delayrun = 50;
            delayrunAction = Jump;
            

        }
        if (goLanding)
        {
            if (--landingcount <= 0)
            {
                AN.SetBool("Landing", false);
                goLanding = false;
            }
        }
    }

    public void Jump()
    {
        goLanding = false;
        AN.SetBool("Jump", false);
        AN.SetBool("Landing", false);
        print("----------------JUMP");
        RB.AddForce(Vector3.up * 500);
        wasLanding=false; 


    }
    public void TurningDone()
    {
        AN.SetBool("Turn Right", false);
        AN.SetBool("Walking", false);
        //transform.Rotate(transform.up, 180);
        lookVector = -Vector3.forward;
    }

    private void OnCollisionEnter(Collision col)
    {
        //if (jumping) return;
        print("COL=" + col.gameObject.tag+":"+col.gameObject.name);
        if (col.gameObject.tag == "Floor" && !wasLanding)
        {
            jumping = false;
            wasLanding = true;
            landingcount = 30;
            print("Hit floor");
            AN.SetBool("Landing", true);
            goLanding = true;
        }
        else print("Hit="+col.gameObject.tag);

    }

    private void OnCollisionExit(Collision collision)
    {
        landingcount = 60;
        goLanding = true;
        //AN.SetBool("Landing", true);
        wasLanding = false;
    }


    public void Death()
    {
        AN.SetBool("Death", true);
        Sounds.Play("pain");
        Gameplay.death = true;
        Gameplay.deathdelay = 200;
        
    }
    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position,transform.forward* 10, Color.red);
    }

}
