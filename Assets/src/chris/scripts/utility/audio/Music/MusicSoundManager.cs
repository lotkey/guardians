using System;
using UnityEngine;

public class MusicSoundManager : MonoBehaviour
{
    public MusicSound[] sounds;
    private MusicSound current = null, next = null;
    [Range(0.0f, 1.0f)]
    public float volumeOfAllMusicSounds = 1.0f;
    private System.Random rand;
    public bool isEnabled = false;
    private float timeToPlayNext = 99999999999999f;
    public MusicType musicType;

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
    }

    private void Update()
    {
        if (isEnabled && Time.unscaledTime >= timeToPlayNext)
        {
            PlayAndScheduleNextPlay();
        }

        // Update the volume
        if (current != null && current.source != null)
        {
            current.source.volume = volumeOfAllMusicSounds;// * current.volume;
        }

        if (next != null && next.source != null)
        {
            next.source.volume = volumeOfAllMusicSounds;// * current.volume;
        }
    }

    // Play the MusicSound with the specified name
    public bool Play(string name)
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

                // Update the references to the current playing clip and the next clip to play
                current = s;
                next = (current.nextMusicSounds.Length > 0)
                    ? sounds[current.nextMusicSounds[rand.Next(0, current.nextMusicSounds.Length)]]
                    : sounds[rand.Next(1, sounds.Length - 1)];

                // Schedule the playing of the next clip after some time
                // The time specified will allow the tails of the current clip to overlap the body of the next clip
                timeToPlayNext = Time.unscaledTime + current.totalLength - current.outroLength - next.introLength;
            }
            return true;
        }
        else
        {
            Debug.LogWarning($"MusicSound \"{name}\" not found!");
            return false;
        }
    }

    // Play the next MusicSound
    public void PlayAndScheduleNextPlay()
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
            next = (current.nextMusicSounds.Length > 0)
                ? sounds[current.nextMusicSounds[rand.Next(0, current.nextMusicSounds.Length)]]
                : sounds[rand.Next(1, sounds.Length - 1)];

            // Schedule the playing of the next clip after some time
            // The time specified will allow the tails of the current clip to overlap the body of the next clip
            timeToPlayNext = Time.unscaledTime + current.totalLength - current.outroLength - next.introLength;
        }
    }

    public void Resume()
    {
        // Cancel all Invokes that will interfere
        CancelInvoke("Stop");
        // Update variable
        isEnabled = true;
        // Play the introduction sound
        Play(sounds[0].name);
    }

    public void Resume(float time)
    {
        // Call the resume function after some time
        Invoke("Resume", time);
    }

    public float Stop()
    {
        float timeUntilMusicIsStopped = 0;
        // If there is a song currently playing...
        if (current != null)
        {
            // Disable the manager
            isEnabled = false;
            // If the current song has a source that is playing
            if (current.source != null && current.source.isPlaying)
            {
                // Skip to the last beat of the song
                float oldVolume = current.source.volume;
                current.source.Stop();
                current.source.Play();
                current.source.time = current.totalLength - current.outroLength;
                // Play the outro snippet
                sounds[sounds.Length - 1].source.Play();
                sounds[sounds.Length - 1].source.volume = oldVolume;
                timeUntilMusicIsStopped = current.outroLength;
            }
            CancelInvoke("Resume");
        }
        next = null;
        // Return the time until the music is stopped playing
        //   so that the music modes do not overlap
        return timeUntilMusicIsStopped;
    }
}