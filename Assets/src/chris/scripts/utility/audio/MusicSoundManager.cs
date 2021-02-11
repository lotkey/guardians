using System;
using UnityEngine.Audio;
using UnityEngine;

public class MusicSoundManager : MonoBehaviour
{
    public MusicSound[] sounds;
    public MusicSound current = null, next = null;
    [Range(0.0f, 1.0f)]
    public float allVolume = 1.0f; // Just a temporary field to test controlling volume
    System.Random rand;
    public float time = 0f;
    public bool isEnabled = true;
    public bool wasEnabled = false;

    private void Awake()
    {
        foreach (MusicSound s in sounds)
        {
            // Convert each measurement from bars to seconds
            //   using the tempo of each MusicSound (in beats ber minute)
            s.bars2sec = 60f / s.tempo * 4f;
            s.length = s.bars2sec * s.lengthInBars;
            s.introLength = s.bars2sec * s.introLengthInBars;
            s.outroLength = s.bars2sec * s.outroLengthInBars;
            s.totalLength = s.length + s.introLength + s.outroLength;

            // Add an AudioSource to each MusicSound so that it can be played
            s.source = gameObject.AddComponent<AudioSource>();
            // Set all the components
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        // Initialize the random variable for random selection later
        rand = new System.Random();

        // If it's enabled, start playing
        if (isEnabled)
        {
            Play(sounds[0].name);
        }
    }

    private void Update()
    {
        // Update the volume
        if (current != null && current.source != null)
        {
            current.source.volume = allVolume;
        }

        if (isEnabled && !wasEnabled) // If this MusicManager was just enabled...
        {
            // Play the intro to start the chain
            Resume();
        }
        else if (wasEnabled && !isEnabled)
        {
            int bar = (int)((Time.time - time) / (current.bars2sec / 4f));
            int nextBar = bar + 1;
            // Cancel Invokes and mutes audio
            Invoke("Stop", (time + (nextBar * current.bars2sec / 4f)) - Time.time);
        }

        wasEnabled = isEnabled;
    }

    // Play the MusicSound with the specified name
    public void Play(string name)
    {
        MusicSound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            if (isEnabled)
            {
                // Play the audio
                if (current != s)
                {
                    // If it is not currently playing, play it normally
                    s.source.Play();
                    s.source.time = 0;
                }
                else
                {
                    // If it is currently playing, play a one shot clip
                    // This means that the currently playing audio will not be stopped when it is played again, 
                    //   even if the clips overlap
                    s.source.PlayOneShot(s.clip);   
                }
                time = Time.time;

                // Update the references to the current playing clip and the next clip to play
                current = s;
                next = sounds[rand.Next(1, sounds.Length - 1)];

                // Invoke the playing of the next clip after some time
                // The time specified will allow the tails of the current clip to overlap the body of the next clip
                if (current.totalLength - current.outroLength - next.introLength >= 0)
                {
                    Invoke("PlayNext", current.totalLength - current.outroLength - next.introLength);
                }
                else
                {
                    Invoke("PlayNext", 0f);
                }
            }
        }
        else
        {
            Debug.LogWarning($"MusicSound \"{name}\" not found!");
        }
    }

    // Play the next MusicSound
    public void PlayNext()
    {
        if (isEnabled)
        {
            // Play the audio
            if (current != next)
            {
                // If it is not currently playing, play it normally
                next.source.Play();
                next.source.time = 0;
            }
            else
            {
                // If it is currently playing, play a one shot clip
                // This means that the currently playing audio will not be stopped when it is played again, 
                //   even if the clips overlap
                next.source.PlayOneShot(next.clip);
            }

            // Update the references to the currently playing MusicSound and the next MusicSound to play
            current = next;
            next = sounds[rand.Next(1, sounds.Length - 1)];

            // Invoke the playing of the next clip after some time
            // The time specified will allow the tails of the current clip to overlap the body of the next clip
            if (current.totalLength - current.outroLength - next.introLength >= 0)
            {
                Invoke("PlayNext", current.totalLength - current.outroLength - next.introLength);
            }
            else
            {
                Invoke("PlayNext", 0f);
            }
        }
    }

    public void Resume()
    {
        CancelInvoke("PlayNext");
        CancelInvoke("Stop");
        isEnabled = true;
        Play(sounds[0].name);
    }

    public void Stop()
    {
        Debug.Log("Stop()!");
        isEnabled = false;
        current.source.Stop();
        next = null;
        CancelInvoke("PlayNext");
        current.source.Play();
        current.source.time = current.totalLength - current.outroLength;
        sounds[sounds.Length - 1].source.Play();
    }

    public void StopAll()
    {
        foreach (MusicSound s in sounds){
            s.source.Stop();
        }
        CancelInvoke("PlayNext");
    }
}