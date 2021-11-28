using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            if (s.name != "song")
                s.source.spatialBlend = 1f;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        Play("song");
    }

    public Sound SetSource(string name, AudioSource aS)
    {
        Sound sound = FindSound(name);
        sound.source = aS;
        sound.source.spatialBlend = 1f;
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
        sound.source.loop = sound.loop;
        return sound;
    }

    public Sound FindSound(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name.Equals(name));
        if (sound == null)
        {
            Debug.Log("No se encuentra el sonido " + name);
            return null;
        }
        return sound;
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name.Equals(name));
        if (sound != null)
        {
            sound.source.Play();
        }
        else
        {
            Debug.Log("No se encuentra el sonido " + name);
        }

    }
}
