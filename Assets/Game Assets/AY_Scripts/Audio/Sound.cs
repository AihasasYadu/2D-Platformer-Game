using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
[System.Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource source;

    public string name;
    public AudioClip clip;
    
    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;
    public bool loop;
}
