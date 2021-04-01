using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    // String name so it can be played by name
    public string name;
    public string filename;

    // Volume ranging from 0 (muted) to 1 (full volume)
    [Range(0f, 1f)]
    public float volume = 1f;
    // Pitch, can be used to randomize pitch to avoid phasing
    [Range(.1f, 3f)]
    public float pitch = 1f;
    public bool randomizePitch = false;
    public float randomPitchRange = 0f;

    // An AudioSource that can be gotten from the AudioClip
    [HideInInspector]
    public AudioSource source;

    public void FromJsound(JSound jsound)
    {
        name = jsound.Name;
        filename = jsound.Filename;
        volume = jsound.Volume;
        pitch = jsound.Pitch;
        randomizePitch = jsound.RandomizePitch;
        randomPitchRange = jsound.RandomPitchRange;
    }
}

[System.Serializable]
public class JSound
{
    public string Name;
    public string Filename;
    public float Volume;
    public float Pitch;
    public bool RandomizePitch;
    public float RandomPitchRange;
}

[System.Serializable]
public class JRoot
{
    public List<JSound> JSound = new List<JSound>();
}