using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public TextAsset jsonFile;
    protected Sound[] sounds = null;
    private static SoundManager instance;
    [Range(0.0f, 1.0f)]
    protected float volumeOfAllSounds = 1.0f;
    protected System.Random rand;

    public static SoundManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        rand = new System.Random();
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

        JRoot JRoot = JsonUtility.FromJson<JRoot>(jsonFile.text);
        sounds = new Sound[JRoot.JSound.Count];
        for (int i = 0; i < JRoot.JSound.Count; i++)
        {
            sounds[i] = new Sound();
            sounds[i].FromJsound(JRoot.JSound[i]);
        }

        // Register an AudioSource for each AudioClip
        //   so that they can be played
        if (sounds != null)
        {
            foreach (Sound s in sounds)
            {
                s.clip = (AudioClip)Resources.Load($"audio/{s.filename}");
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }
    }

    private void Update()
    {
    }

    public bool Play(string name)
    {
        // Find the first sound in sounds with the name of string name
        if (sounds != null)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s != null)
            {
                
                float pitchOffset = 1.0f;
                if (s.randomizePitch)
                {
                    float max = s.randomPitchRange / 2f;
                    float min = -s.randomPitchRange / 2f;
                    pitchOffset += (float)rand.NextDouble() * (max - min) + min;
                }

                s.source.pitch = pitchOffset;

                if (s.source.isPlaying) // If it's already playing...
                {
                    // Play a oneshot so that it will overlap
                    s.source.PlayOneShot(s.clip);
                }
                else // Otherwise...
                {
                    // Play the sound and add it to the currentSounds list
                    s.source.Play();
                }
                return true;
            }
            else
            {
                Debug.LogWarning("Sound \"" + name + "\" not found!");
                return false;
            }
        }
        else
        {
            Debug.Log("No sounds!");
            return false;
        }
    }

    public void PlayAtPoint(string name, Vector2 point)
    {
        // Find the first sound in sounds with the name of string name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            float pitchOffset = 0f;
            if (s.randomizePitch)
            {
                float max = s.randomPitchRange / 2f;
                float min = -s.randomPitchRange / 2f;
                pitchOffset = (float)rand.NextDouble() * (max - min) + min;
            }
            AudioSource.PlayClipAtPoint(s.clip, point);
        }
        else
        {
            Debug.LogWarning($"Sound \"{name}\" not found!");
        }
    }

    // Takes a float from 0 to 1 and sets it to be the volume
    public void SetVolume(float newVolume)
    {
        volumeOfAllSounds = Sound.LinearToLog(newVolume);
        if (sounds != null)
        {
            foreach (Sound s in sounds)
            {
                if (s.source != null)
                {
                    // Update the volume of each currently playing sound effect
                    s.source.volume = volumeOfAllSounds * s.volume;
                }
            }
        }
    }
}