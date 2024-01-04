using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour
{
    public bool going;
    private bool arrived;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Go()
    {
        if (!arrived)
        {
            arrived = true;
            going = true;
            Sounds.Play("elevate");
        }
    }
}
