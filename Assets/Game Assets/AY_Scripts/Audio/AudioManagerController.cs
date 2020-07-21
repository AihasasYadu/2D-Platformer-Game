using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using JetBrains.Annotations;
using System;

public class AudioManagerController : MonoBehaviour
{
    public Sound[] sounds;
    private static AudioManagerController instance;
    private string themeMusicName = "Theme";
    public static AudioManagerController Instance { get { return instance; } }
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.name = s.name;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }   
    }
    private void Start()
    {
        Play(themeMusicName);
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("Incorrect File Name/File Not Found : " + name);
            return;
        }
        s.source.Play();
    }  
}
