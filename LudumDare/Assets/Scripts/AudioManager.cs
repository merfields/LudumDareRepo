using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    Sound[] sounds;

    private void Awake() {
        foreach (Sound item in sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;

            item.source.volume = item.volume;
            item.source.pitch = item.pitch;
            item.source.loop = item.loop;
        }
    }

    private void Start() {
        PlayClip("Main Theme");
    }

    public void PlayClip(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s!=null)
        s.source.Play();
    }

    public void StopClip(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
