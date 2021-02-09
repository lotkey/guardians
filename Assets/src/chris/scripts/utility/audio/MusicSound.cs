using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class MusicSound : Sound
{
    public int mode; 

    public float tempo;
    public float lengthInBars;
    public float introLengthInBars;
    public float outroLengthInBars;

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
}
