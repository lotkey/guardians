using UnityEngine;

[System.Serializable]

public class MusicSound : Sound
{
    // Tempo in beats-per-minute of the MusicSound
    public float tempo;
    // Lengths of the segments in bars
    public float lengthInBars;
    public float introLengthInBars;
    public float outroLengthInBars;

    // Lengths of segments in floats
    [HideInInspector]
    public float length;
    [HideInInspector]
    public float introLength;
    [HideInInspector]
    public float outroLength;
    [HideInInspector]
    public float totalLength;
    [HideInInspector]
    public float bars2sec;

    // List of indices that can be played next
    public int[] nextMusicSounds;
}
