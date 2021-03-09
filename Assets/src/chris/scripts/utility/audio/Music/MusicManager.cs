using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // List of MusicSoundManagers for each MusicType
    public MusicSoundManager[] music;
    // Adjustable volume from 0 (muted) to 1 (full volume)
    [Range(.0001f, 1f)]
    public float volume;
    private float previousVolume = 0f;
    // The current MusicType
    public MusicType currentMusicType = MusicType.AMBIENT;
    private MusicSoundManager startingMusicSoundManager;
    private bool started = false;

    private void Start()
    {
        // Enable the correct MusicSoundManager and disable the rest
        for (int i = 0; i < music.Length; i++) {
            if (music[i] != null)
            {
                if (music[i].musicType == currentMusicType)
                {
                    Debug.Log($"Resuming {currentMusicType}");
                    startingMusicSoundManager = music[i];
                }
                else if (music[i].sounds.Length > 0)
                {
                    Debug.Log($"Stopping {currentMusicType}");
                    music[i].Stop();
                }
            }
            else
            {
                Debug.LogWarning($"The MusicManager has null MusicSoundManagers or MusicSoundManagers with no MusicSounds at index {i}.");
            }
            music[i].volumeOfAllMusicSounds = Mathf.Log10(volume) * 20;
        }
    }

    private void Update()
    {
        if (!started && !startingMusicSoundManager.isEnabled)
        {
            startingMusicSoundManager.Resume();
            started = true;
        }
        // If there has been a change in volume, change the volume of all music sound managers
        // Otherwise, don't bother looping through to avoid wasting performance
        if (previousVolume != volume)
        {
            foreach (MusicSoundManager m in music)
            {
                m.volumeOfAllMusicSounds = (volume > 1) ? 1 : volume;
            }
        }
        previousVolume = volume;
    }

    public void SwitchMode(MusicType musicType)
    {
        // Stop the current MusicSoundManager and play the next MusicSoundManager
        float timeUntilNewMusicTimePlays = 0;
        MusicSoundManager next = Array.Find(music, msManager => msManager.musicType == musicType);
        MusicSoundManager current = Array.Find(music, msManager => msManager.musicType == currentMusicType);
        if (current != null) timeUntilNewMusicTimePlays = current.Stop();
        if (next != null) next.Resume(timeUntilNewMusicTimePlays);
        currentMusicType = musicType;
    }

    public MusicType GetCurrentMode()
    {
        return currentMusicType;
    }
}

// Much more understandable to use than just integers
// Example:
//   currentMusicType = 0; <- not good
//   currentMusicType = MusicType.AMBIENT; <- better
public enum MusicType
{
    MAINMENU = 0,
    AMBIENT = 1,
    WAVE = 2,
    BOSS = 3
}