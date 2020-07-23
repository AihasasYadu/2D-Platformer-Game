using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using JetBrains.Annotations;
using System;

public class AudioManagerController : MonoBehaviour
{
    public Sound[] soundArray;
    private static AudioManagerController instance;
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
        foreach (Sound s in soundArray)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.name = s.name;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }   
    }
    public void Play(AudioTitles audio)
    {
        Sound sound = GetTitleName(audio);
        if(sound == null)
        {
            Debug.Log("Incorrect File Name/File Not Found : " + name);
            return;
        }
        sound.source.Play();
    }  
    private Sound GetTitleName(AudioTitles a)
    {
        Sound s = Array.Find(soundArray, sound => sound.name.Equals(a.ToString()));
        return s;
    }
    public void Mute(AudioTitles audio)
    {
        Sound sound = GetTitleName(audio);
        sound.source.mute = true;
    }
    public void Unmute(AudioTitles audio)
    {
        Sound sound = GetTitleName(audio);
        sound.source.mute = false;
    }
    public void Stop(AudioTitles audio)
    {
        Sound sound = GetTitleName(audio);
        sound.source.Stop();
    }
}
