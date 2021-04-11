using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;
    // List of MusicSoundManagers for each MusicType
    public MusicSoundManager[] music;
    // Adjustable volume from 0 (muted) to 1 (full volume)
    protected float volume;
    // The current MusicType
    public MusicType currentMusicType = MusicType.AMBIENT;
    protected bool started;
    protected MusicSoundManager startingMusicSoundManager = null;

    public static MusicManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        volume = 1f;
        // Enable the correct MusicSoundManager and disable the rest
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i] != null)
            {
                if (music[i].musicType == currentMusicType)
                {
                    startingMusicSoundManager = music[i];
                }
                else if (music[i].sounds.Length > 0)
                {
                    music[i].Stop();
                }
            }
            else
            {
                Debug.LogWarning($"The MusicManager has null MusicSoundManagers or MusicSoundManagers with no MusicSounds at index {i}.");
            }
            music[i].SetVolume(volume);
        }
    }

    private void Update()
    {
        if (!started && !startingMusicSoundManager.isEnabled)
        {
            startingMusicSoundManager.Resume();
            started = true;
        }
    }

    public void SwitchMode(MusicType musicType)
    {
        if (musicType != currentMusicType)
        {
            // Stop the current MusicSoundManager and play the next MusicSoundManager
            float timeUntilNewMusicTimePlays = 0;
            MusicSoundManager next = Array.Find(music, msManager => msManager.musicType == musicType);
            MusicSoundManager current = Array.Find(music, msManager => msManager.musicType == currentMusicType);
            if (current != null) timeUntilNewMusicTimePlays = current.Stop();
            if (next != null) next.Resume(timeUntilNewMusicTimePlays);
            currentMusicType = musicType;
        }
    }

    public MusicType GetCurrentMode()
    {
        return currentMusicType;
    }

    public void SetVolume(float newVolume)
    {
        volume = Sound.LinearToLog(newVolume);
        foreach(MusicSoundManager m in music)
        {
            if (m != null)
            {
                m.SetVolume(volume);
            }
        }
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