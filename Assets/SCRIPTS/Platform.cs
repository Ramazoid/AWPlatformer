using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Receptor
{
    public int delta;
    public Vector3 vectorTo;

    void Start()
    {
        vectorTo = transform.position - Vector3.up * delta;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (going)
        {
            print("moving"+transform.position);
            transform.position = Vector3.Lerp(transform.position, vectorTo, 0.01f);
        }
    }
}
