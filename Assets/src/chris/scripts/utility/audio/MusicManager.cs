using System;
using UnityEngine.Audio;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public MusicSound[] sounds;
    public MusicSound current, next;
    System.Random rand;
    public float time;
    public bool isEnabled = true;
    public bool wasEnabled = false;

    private void Awake()
    {
        foreach (MusicSound s in sounds)
        {
            s.bars2sec = 60f / s.tempo * 4f;
            s.length = s.bars2sec * s.lengthInBars;
            s.introLength = s.bars2sec * s.introLengthInBars;
            s.outroLength = s.bars2sec * s.outroLengthInBars;
            s.totalLength = s.length + s.introLength + s.outroLength;

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        rand = new System.Random();

        if (isEnabled)
        {
            Play(sounds[0].name);
        }
    }

    private void FixedUpdate()
    {
        if (isEnabled && !wasEnabled)
        {
            Play(sounds[0].name);
        }
        else if (isEnabled)
        {
            if ((Time.time - time) >= (current.length + current.introLength - next.introLength))
            {
                Play(next.name);
            }
        }

        wasEnabled = isEnabled;
    }

    public void Play(string name)
    {
        MusicSound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            Debug.Log($"Played {name}");
            time = Time.time;
            s.source.PlayOneShot(s.clip);
            current = s;
            next = sounds[rand.Next(1, sounds.Length)];
        }
        else
        {
            Debug.LogWarning($"MusicSound \"{name}\" not found!");
        }
    }

    public void Resume()
    {
        isEnabled = true;
    }

    public void Pause()
    {
        isEnabled = false;
    }
}