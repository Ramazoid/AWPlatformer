using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDriver : MonoBehaviour
{
    public Transform PlayerBase;
    public int distance;
    public int elevate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerBase.position + Vector3.right * distance + Vector3.up * elevate;
    }
}
