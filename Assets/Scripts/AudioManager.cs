using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys

    public Sound[] sounds;
    String scene;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        if (scene.Equals("ConvenienceStore"))
        {
            Play("Convenience Theme");
        }
        else if (scene.Equals("WinScreen"))
        {
            Play("Win Theme");
        }
        else if (scene.Equals("TitleScene"))
        {
            Play("Title Theme");
        }
        else if (scene.Equals("Barabar"))
        {
            Play("Barabar Theme");
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("The sound " + name + " was not found.");
            return;
        }
        s.source.Play();
    }
}
