# The Sound Manager
Chris McVickar  
IT Manager  
Pseudo Random Studios (PRS)

## An Overview
---

The Sound Manager is a system comprised of multiple classes:  
- Sound
- SoundManager
- JSound
- JRoot

A user of this Sound Manager system will only have to interface with the Sound Manager class.

The Sound Manager system also uses the Resource directory in the Unity project as well as a JSON file inside of that directory.

The foundation of the Sound Manager system is inspired by a Brackeys tutorial video. Click [this link](https://youtu.be/6OT43pvUyfY) to open the tutorial video in your browser. 

## Classes
---

### Sound

The Sound class stores an AudioClip, AudioSource, a name, and some customization options:  
- volume
  - Floating point number
  - Determines the playback volume of the clip
  - 0 means muted, 1 means normal volume, anything above 1 is amplifying the clip
- pitch
  - Floating point number
  - Determines the playback pitch of the clip
  - Anything below 1 means lower pitch, 1 means normal volume, anything above 1 is higher pitch
- randomizePitch: 
  - Boolean
  - Determines whether or not the playback pitch of the clip is determined randomly from some range
  - True means pitch will be randomized, false will mean no randomization
- randomPitchRange: 
  - Floating point number
  - A range that a playback pitch will be selected from if randomized pitches are enabled
  - Centered around *pitch*

The Sound class also has a static function:
- LinearToLog(float linear)
  - Convert numbers on a linear scale to numbers on a logarithmic scale. 
  
### SoundManager : MonoBehaviour

The SoundManager class is the only class the user directly interfaces with. It loads sound files from a directory as instances of the Sound class and plays certain sounds on request. The SoundManager class has various fields and methods.

**Fields:**
- jsonFile
  - Unity text asset
  - A reference to a json file that has text that contains paths and attributes of sounds to be played
- sounds
  - A Sound array
  - Contains references to instances of *Sound* that will be loaded in using *jsonFile*
- instance
  - SoundManager reference
  - A reference to the single SoundManager
  - The SoundManager is a singleton
- volumeOfAllSounds
  - Floating point number
  - Global volume across all sounds
- rand
  - A random number generator
  - Used for randomizing pitch  

**Methods:**
- GetInstance()
  - Returns the single instance of the SoundManager class
- Awake()
  - Inherited from MonoBehaviour
  - Assigns *instance* if unassigned, otherwise destroys itself
  - Loads a Sound array from the JSON file
  - Registers a Unity AudioSource to each Sound in the array
- Play(string name)
  - Plays the first Sound s in the array *sounds* where *s.name* is equal to *name*
  - Randomizes pitch if enabled
- SetVolume(float newVolume)
  - Sets the global volume for all sounds in the array

### JSound

The only purpose of the JSound class is to aid in reading in a Sound array from the JSON file. It contains several fields:
- Name
- Filename
  - Relative path from the Resources/audio/ to the audio file
  - No file extension (*audiofile* instead of *audiofile.wav* or *audiofile.m4a*)
- Volume
- Pitch
- RandomizePitch
- RandomPitchRange

This class is not meant to be used elsewhere and is not useful elsewhere. The onnl reason this class exists is because reading a list from a JSON file using the Unity json Utility libraries is a little tedious.

### JRoot

The only purpose of the JRoot class is to aid in reading in a Sound array from the JSON file. It contains a single field:
- JSound
  - List of JSound

This class is not meant to be used elsewhere and is not useful elsewhere. The onnl reason this class exists is because reading a list from a JSON file using the Unity json Utility libraries is a little tedious.

## The JSON Portion
---

The user can add playable sounds to their project using a JSON file and the Resources directory in the Unity project. This method can be more intuitive than using the Unity inspector, especially in a large game with thousands of sounds. The JSON file must be referenced by the SoundManager. The sound files must be in Resources/audio/.

Inside the JSON file is a single object "JSound". That single object is converted to a Sound array. Below is a sample of what the contents could look like.

```
{
  "JSound": [
    {
      "Name": "meleeSwipeFail",
      "Filename": "chris/meleeSwipeFail",
      "Volume": 1.0,
      "Pitch": 1.0,
      "RandomizePitch": true,
      "RandomPitchRange": 0.1
    },

    {
      "Name": "meleeSwipeSuccess",
      "Filename": "chris/meleeSwipeSuccess",
      "Volume": 1.0,
      "Pitch": 1.0,
      "RandomizePitch": true,
      "RandomPitchRange": 0.1
    },

    {
      "Name": "gunshot",
      "Filename": "chris/guardiansgunshot",
      "Volume": 1.0,
      "Pitch": 1.0,
      "RandomizePitch": true,
      "RandomPitchRange": 0.1
    }
  ]
}
```