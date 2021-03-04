using System;
using UnityEngine.Audio;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public MusicSoundManager[] music;
    [Range(0, 1f)]
    public float volume;
    public MusicType mode = MusicType.AMBIENT;

    private void Start()
    {
        for (int i = 0; i < music.Length; i++) {
            if (music[i] != null)
            {
                if (music[i].musicType == mode)
                {
                    Debug.Log($"Resuming {mode}");
                    music[i].Resume();
                }
                else if (music[i].sounds.Length > 0)
                {
                    Debug.Log($"Stopping {mode}");
                    music[i].Stop();
                }
            }
            else
            {
                Debug.LogWarning($"The MusicManager has null MusicSoundManagers or MusicSoundManagers with no MusicSounds at index {i}.");
            }
        }
    }

    private void Update()
    {
        foreach (MusicSoundManager m in music)
        {
            m.volumeOfAllMusicSounds = (volume > 1) ? 1 : volume;
        }
    }

    public void SwitchMode(MusicType musicType)
    {
        float timeUntilNewMusicTimePlays = 0;
        MusicSoundManager next = Array.Find(music, msManager => msManager.musicType == musicType);
        MusicSoundManager current = Array.Find(music, msManager => msManager.musicType == mode);
        if (current != null) timeUntilNewMusicTimePlays = current.Stop();
        if (next != null) next.Resume(timeUntilNewMusicTimePlays);
        mode = musicType;
    }

    public MusicType CurrentMode()
    {
        return mode;
    }
}

public enum MusicType
{
    MAINMENU = 0,
    AMBIENT = 1,
    WAVE = 2,
    BOSS = 3
}