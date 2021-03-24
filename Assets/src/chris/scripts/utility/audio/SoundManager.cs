using System;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private Sound[] sounds;
    private static SoundManager instance;
    [Range(0.0f, 1.0f)]
    public float volumeOfAllSounds = 1.0f; // Just a temporary field to test controlling volume
    private List<Sound> currentSounds;

    private void Awake()
    {
        // There can only be one SoundManager active
        //   and it will not destroy itself between scene changes
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        // Register an AudioSource for each AudioClip
        //   so that they can be played
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Update()
    {
        foreach (Sound s in currentSounds)
        {
            if (s.source != null)
            {
                // Update the volume of each currently playing sound effect
                s.source.volume = volumeOfAllSounds * s.volume;
                if (!s.source.isPlaying)
                {
                    // If the audio source is no longer playing, 
                    //   remove it from the currently playing sounds list
                    currentSounds.Remove(s);
                }
            }
        }
    }

    public bool Play(string name)
    {
        // Find the first sound in sounds with the name of string name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            if (s.source.isPlaying) // If it's already playing...
            {
                // Play a oneshot so that it will overlap
                s.source.PlayOneShot(s.clip);
                if (!currentSounds.Contains(s))
                {
                    currentSounds.Add(s);
                }
            }
            else // Otherwise...
            {
                // Play the sound and add it to the currentSounds list
                s.source.Play();
                currentSounds.Add(s);
            }
            return true;
        }
        else
        {
            Debug.LogWarning("Sound \"" + name + "\" not found!");
            return false;
        }
    }

    public void PlayAtPoint(string name, Vector2 point)
    {
        // Find the first sound in sounds with the name of string name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            AudioSource.PlayClipAtPoint(s.clip, point);
            currentSounds.Add(s);
        }
        else
        {
            Debug.LogWarning($"Sound \"{name}\" not found!");
        }
    }
}