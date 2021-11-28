using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public String name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume = 1f;

    [Range(0.1f,3f)]
    public float pitch= 0.1f;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
