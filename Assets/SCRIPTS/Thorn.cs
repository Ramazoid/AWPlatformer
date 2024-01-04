using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    public int elevate;
    private int elevateDelay;
    private int thornumber;
    private bool goElevate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goElevate && --elevateDelay<=0)
        {
            elevateDelay = 20;
            Transform t = transform.GetChild(thornumber++);
            t.position += Vector3.up * elevate;
            Sounds.Play("blade", 2);
            if (thornumber == transform.childCount)
                goElevate = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        print("COLLIDED:" + col.gameObject.tag);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            elevateDelay = 20;
            thornumber = 0;
            goElevate = true;
            col.gameObject.SendMessage("Death");
           
        }
    }

}
