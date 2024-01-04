using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBaloons : MonoBehaviour
{
    public Camera cam;
    public RectTransform baloon;
    private static  UIBaloons INST;

    public static RectTransform ShowBaloon(GameObject word, string code)
    {
        INST.baloon.gameObject.SetActive(true);
        Text t = INST.baloon.GetComponentInChildren<Text>();
        t.text = code;
       
        return INST.baloon;
    }

    private void Awake()
    {
        INST = this;
    }


    void Start()
    {
        cam = Camera.main;
        baloon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
