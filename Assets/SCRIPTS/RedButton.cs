using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    private Renderer Ren;
    private bool red;
    private int switchcount;
    private Camera cam;
    public KeyCode code;

    public RectTransform baloon;
    public bool ready;
    public Receptor receptor;
    void Start()
    {
        Ren = GetComponent<Renderer>();
        red = false; ; switchcount = 5;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (switchcount-- <= 0)
        {
            red = !red;
            Ren.material.color = (red ? Color.red : Color.white);
            ; switchcount = 5;
        }
        if(baloon!=null)
        {
            Vector3 pos = cam.WorldToScreenPoint(transform.position);
            baloon.position = pos;

            if(Input.GetKey(code)&& ready)
            {
                receptor.Go();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        ready = true;
        print("Button collision" + col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            baloon = UIBaloons.ShowBaloon(gameObject, code.ToString());
            Sounds.Play("pbaloonOn");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        baloon.gameObject.SetActive(false);
        ready = false;
        baloon = null;
        Sounds.Play("baloonOff");
    }


}
