using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SoundManagerTests
{
    [UnityTest]
    public IEnumerator PlayNonexistentSoundTest()
    {
        GameObject gameObject = new GameObject();
        SoundManager soundManager = gameObject.AddComponent<SoundManager>();
        Assert.AreEqual(expected: false, actual: soundManager.Play("This should return false because there is no sound with this name"));
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayNonexistentMusicSoundTest()
    {
        GameObject gameObject = new GameObject();
        MusicSoundManager musicSoundManager = gameObject.AddComponent<MusicSoundManager>();
        Assert.AreEqual(expected: false, actual: musicSoundManager.Play("This should return false because there is no sound with this name"));
        yield return null;
    }
}
