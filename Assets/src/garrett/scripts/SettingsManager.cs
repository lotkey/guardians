using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{

	public AudioMixer audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Toggle Windowed Setting
    public void ToggleWindowed(bool arg)
    {
        Screen.fullScreen = arg;
    }

    // change volume with slider
    // TODO: expose the volume variable in audio mixer
    public void SetVolume(float vol)
    {
    	Debug.Log("setting volume to " + vol);
    	// audio.SetFloat("volume", volume); // TODO: attach this
    }

    // set the quality level of the game
    // attach to drop down in settings menu
    public void SetQuality(int index)
    {
    	QualitySettings.SetQualityLevel(index);
    }
}
