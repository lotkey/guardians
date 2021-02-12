using System;
using UnityEngine.Audio;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public MusicSoundManager[] music;
    public float volume;
    public int mode = 0;

    private void Start()
    {
        for (int i = 1; i < music.Length; i++) {
            if (music[i] != null && music[i].sounds.Length > 0)
            {
                music[i].Stop();
            }
            else
            {
                Debug.LogWarning($"The MusicManager has null MusicSoundManagers or MusicSoundManagers with no MusicSounds.");
            }
        }
    }

    private void Update()
    {
    }

    public void SwitchMode(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].musicType.ToLower() == name)
            {
                SwitchMode(i);
                return;
            }
        }

        Debug.Log($"Mode {name} is not recognized.");
    }

    public void SwitchMode(int modeID)
    {
        if (modeID >= 0 && modeID <= 3)
        {
            for (int i = 0; i < music.Length; i++)
            {
                if (i == modeID && mode != modeID)
                {
                    mode = modeID;
                    music[i].Resume(5);
                }
                else if (i != modeID)
                {
                    if (music[i] != null && music[i].sounds.Length > 0)
                    {
                        music[i].Stop();
                    }
                }
            }
        }
    }
}