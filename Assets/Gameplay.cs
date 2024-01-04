using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public Image fader;
    private bool fadeout;
    internal static bool death;
    internal static int deathdelay;

    void Start()
    {
        fadeout = true;
    }

    private void FadeOut()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeout)
        {
            Color32 deltaColor = new Color(0, 0, 0, 0.01f);
            fader.color -= deltaColor;
           
        }
        if (death && --deathdelay <= 0)
        {
            Restart();
            death = false;
        }
        
    }

    internal static void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
