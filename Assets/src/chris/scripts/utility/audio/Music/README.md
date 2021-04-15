# The Music Manager
Chris McVickar  
IT Manager  
Pseudo Random Studios (PRS)

## An Overview
---

The Music Manager is a system comprised of multiple classes:  
- MusicType (enum)
- MusicSound
- MusicSoundManager
- MusicManager

A MusicSound is inherited from the Sound class and is geared specifically towards music. A MusicSoundManager is a group of MusicSounds. A MusicManager manages several MusicSoundManagers. Each of the MusicSoundManagers may have different MusicTypes. Different types of music can be triggered through the MusicManager.

The job of the MusicSoundManager is to manage MusicSounds. A MusicSound should be a very short segment of a song, roughly four to sixteen bars in 4/4. Each MusicSound will have a list of MusicSounds that it can transition to. The MusicSoundManager will manage these transitions, ensuring that tails (such as reverb tails) do not get cut off or intros (such as a swell or riser) overlaps with the previous MusicSound.

## Classes
---

### MusicType

MusicType is an enumerator. In this case it is much more understandable to use an enumerator than integers. MusicType can be used to indicate what type of music something is. For example, MusicType has four values in Guardians: MAINMENU, AMBIENT, WAVE, and BOSS. There is different music for the main menu, for ambient gameplay, for wave fighting, and for boss fights that can be indicated by a MusicType variable.

### MusicSound : Sound

The MusicSound inherits from the Sound class and contains all inherited fields and methods. It also contains additional fields:
- tempo
  - Floating point number
  - Tempo
  - Beats-per-minute
- lengthInBars
  - Floating point number
  - Number of 4/4 bars of the body of the music segment
- introLengthInBars
  - Floating point number
  - Number of 4/4 bars of the intro of the music segment
  - Will overlap with the previously played MusicSound's body
- outroLengthInBars
  - Floating point number
  - Number of 4/4 bars of the outro of the music segment
  - Will overlap with the next played MusicSound's body

The following fields are not specified by the user:
- length
  - Floating point number
  - Length of body in seconds
- introLength
  - Floating point number
  - Length of intro in seconds
- outroLength
  - Floating point number
  - Length of outro in seconds
- totalLength
  - Floating point number
  - Length of the entire segment in seconds
- bars2sec
  - Floating point number
  - Used to convert from bars to seconds
- nextMusicSounds
  - Integer array
  - Contains the index of the MusicSounds that can be played next
  - Index refers to index of the *sounds* array in the MusicSoundManager class

### MusicSoundManager : MonoBehaviour

The MusicSoundManager's job is to schedule the playing of music segments.

Imagine a directed, cyclic graph. Each vertex is an instance of MusicSound. Each directed edge is a possible transition from one MusicSound to another. The MusicSoundManager will pick a dedicated starting vertex, play that MusicSound, and then pseudo-randomly pick one of the possible edges to traverse to the next MusicSound and repeat until it is paused.

**Fields:**
- sounds
  - MusicSound array
- current, next
  - MusicSounds
  - References to the currently playing MusicSound and the next MusicSound to be played
- volumeOfAllSounds
  - Floating point number
  - Global volume across all the MusicSounds
- rand
  - Random number generator
  - Used to pseudo-randomly traverse through the MusicSound array
- isEnabled
  - Boolean
  - Indicates whether or not the MusicSoundManager is enabled and should be playing music
- timeToPlayNext
  - Floating point number
  - The time when the next MusicSound should be played
- musicType
  - MusicType
  - The type of music that the MusicSoundManager manages
- resuming
  - Boolean
  - Indicates whether or not the MusicSoundManager is in the process of being resumed
- resumeTime
  - The amount of time until the MusicSoundManager is resumed

**Methods:**
- Awake()
  - Registers AudioClips to each MusicSound and initializes variables
- Update()
  - Play the next MusicSound at the correct time
  - Handle resuming
- Play(string name)
  - Play the MusicSound with the name *name*
- PlayAndScheduleNextPlay()
  - Play the next MusicSound and update the *current* and *next* references
- Resume()
  - Resumes the MusicSoundManager
- Resume(float time)
  - Resumes the MusicSoundManager after time *time* in seconds
- Stop()
  - Stops the MusicSoundManager
- SetVolume(float newVolume)
  - Sets the global volume of the MusicSounds in the MusicSoundManager

### MusicManager : MonoBehaviour

The MusicManager's job is easier than the MusicSoundManager's job. The MusicManager will pause and resume MusicSoundManagers in order to make sure that only a single MusicSoundManager, one with the correct MusicType, is playing at any given time. The MusicManager is a singleton.

**Fields:**
- instance
  - MusicManager
  - The single instance of MusicManager
- music
  - MusicSoundManager array
- volume
  - Floating point number
  - Global volume across all of *music*
- currentMusicType
  - MusicType
  - Current type of music that is being played
- started
  - Boolean
  - Used to control the starting of the MusicManager
  - Timing was off when using the MonoBehaviour functions Start() and Awake()
- startingMusicSoundManager
  - MusicSoundManager
  - The MusicSoundManager that will play when the MusicManager starts playing

**Methods:**
- GetInstance()
  - Returns a reference to the singleton
- Awake()
  - Sets *instance*
- Start()
  - Stops all MusicSoundManagers that are not the correct type and sets *startingMusicManager*
- Update()
  - Handles starting
- SwitchMode(MusicType musicType)
  - Pauses all MusicSoundManagers m where *m.musicType* is not *musicType* and resumes the first MusicSoundManager with the correct music type
- GetCurrentmode()
  - Returns the current MusicType
- SetVolume(float volume)
  - Sets the global volume of all music