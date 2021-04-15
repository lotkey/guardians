using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{

    // Toggle Windowed Setting
    public void ToggleWindowed(bool arg)
    {
        Screen.fullScreen = arg;
    }

    // change volume with slider
    public void SetVolume(float vol)
    {
    	Debug.Log("setting volume to " + vol);
    	MusicManager.GetInstance().SetVolume(vol);
    }

    // change sfx volume with slider
    public void SetSFXVolume(float vol)
    {
        Debug.Log("setting SFX volume to " + vol);
        SoundManager.GetInstance().SetVolume(vol);
    }

    // set the quality level of the game
    // attach to drop down in settings menu
    public void SetQuality(int index)
    {
    	QualitySettings.SetQualityLevel(index);
    }
}
