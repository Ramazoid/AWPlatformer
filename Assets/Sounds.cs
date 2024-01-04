using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public List<AudioClip> clips;
    private AudioSource player;
    private static Sounds I;
    public Queue<AudioClip> clipqueue= new Queue<AudioClip>();

    internal static void Play(string clipname,int volume=1)
    {
        AudioClip clip = I.clips.Find(c => c.name == clipname);
        print("--"+clip);
        if (clip != null)
        {
            I.player.clip =null;
            I.clipqueue.Enqueue(clip);
            I.player.volume = volume;
            I.player.Play();
        }
        else
            throw new Exception($"clip{clipname} not found");
    }

    private void Awake()
    {
        I = this;
    }

    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clipqueue.Count > 0&&!player.isPlaying)
        {
            player.clip = clipqueue.Dequeue();
            player.Play();
        }
    }
}
