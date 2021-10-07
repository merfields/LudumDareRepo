using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField]
    public string name;

    [SerializeField]
    public AudioClip clip;

    [SerializeField]
    [Range(0f,1f)]
    public float volume;
    
    [SerializeField]
    [Range(0f,1f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}
