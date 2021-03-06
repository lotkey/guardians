using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    // String name so it can be played by name
    public string name;

    // Volume ranging from 0 (muted) to 1 (full volume)
    [Range(0f, 1f)]
    public float volume = 1f;
    // Pitch, can be used to randomize pitch to avoid phasing
    [Range(.1f, 3f)]
    public float pitch = 1f;
    // Whether or not a sound loops
    public bool loop;

    // An AudioSource that can be gotten from the AudioClip
    [HideInInspector]
    public AudioSource source;
}