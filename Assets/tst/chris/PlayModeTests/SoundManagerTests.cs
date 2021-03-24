using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SoundManagerTests
{
    [UnityTest]
    // Boundary test for the SoundManager class
    // Attempting to play a sound by name
    //   where there is no sound with the specified name
    public IEnumerator PlayNonexistentSoundTest()
    {
        // Instantiate a new GameObject and add a SoundManager to it
        GameObject gameObject = new GameObject();
        SoundManager soundManager = gameObject.AddComponent<SoundManager>();
        // The SoundManager has no sounds added to it, so any string should fail
        // In the case that no sound exists, the Play() function will return false
        Assert.AreEqual(expected: false, actual: soundManager.Play("This should return false because there is no sound with this name"));
        yield return null;
    }

    [UnityTest]
    // Boundary test for the MusicSoundManager class
    // Attempting to play a musicSound by name
    //   where there is no musicSound with the specified name
    public IEnumerator PlayNonexistentMusicSoundTest()
    {
        // Instantiate a new GameObject and add a MusicSoundManager to it
        GameObject gameObject = new GameObject();
        MusicSoundManager musicSoundManager = gameObject.AddComponent<MusicSoundManager>();
        // The MusicSoundManager has no sounds added to it, so any string should fail
        // In the case that no sound exists, the Play() function will return false
        Assert.AreEqual(expected: false, actual: musicSoundManager.Play("This should return false because there is no sound with this name"));
        yield return null;
    }
}
