# Guardians/Assets/src/chris/

# Chris M

## Feature 1: Entity Movement

This feature will require two different types of classes: an Entity class and an EntityMovement class. 

### class Entity : MonoBehavior

The Entity class will inherit from MonoBehavior. An Entity will consist of:
  - A reference to a Rigidbody2D for physics
  - A reference to an EntityMovement
  - Attack damage, health, maximum health
	  - Could be moved to a separate Combat script later
  - Speed
  - Eventually, a reference to an Animator

The Player class will inherit from the Entity class and will consist of:
  - All inherited fields
  - A reference to a PlayerController
  - A reference to a PlayerMovement which will hide the inherited EntityMovement reference

### class EntityMovement : MonoBehavior

The EntityMovement class will inherit from MonoBehavior. It will consist of:
  - A reference to the Entity that it will move
	  - Necessary to access the Rigidbody2D and speed
  - Methods to move the Rigidbody2D along the x- and y-axes
	  - Takes in a value of [-1.0, 1.0] for both the x- and y-axes
	  - Also takes in a value for the elapsed time since the last Update/FixedUpdate

The PlayerMovement class will inherit from the Entity class and will consist of:
  - All inherited fields and methods
  - An reference to a Player that will hide the inherited Entity reference
  - Eventually, any individual movement abilities that are exclusive to the player. Potential examples:
	  - Dodge
	  - Dash
	  - Slide

## Feature 2: Sound Management

Following [Brackey's Sound Manager tutorial](https://www.youtube.com/watch?v=6OT43pvUyfY), general Sound Management will involve two classes: a Sound class and a SoundManager class.

### class Sound

The Sound class will consist of:
  - An instance of AudioClip
  - A name
  - Controllable volume and pitch
  - Ability to loop
  - An instance of AudioSource

The MusicSound class will inherit from the Sound class and will consist of:
  - All inherited fields and methods
  - A tempo (in beats-per-minute)
	  - This will be necessary to convert units from bars to seconds
  - An intro length, body length, and tail length in bars
	  - The intro will account for pickup notes
		  - This can overlap with the body of previous MusicSounds
	  - The body will be able to overlap with the outro of the previous MusicSound and the intro of the next MusicSound
	  - The outro will account for sounds that fade out
		  - Drum hits that have a long decay
		  - Reverb and delay tails
		  - Synths and other instruments with long releases
		  - Etc.
- A tag for different types of sounds
	- Ambient
	- Combat
	- Boss fight
	- Etc.

### class SoundManager : MonoBehavior

The SoundManager will store Sounds and play them. It is a child of MonoBehavior. It will consist of:
  - An array of Sounds
  - A Start( ) method that adds a playable AudioSource to each Sound
  - A Play( ) functions that takes a string and plays a Sound with a name that matches the string

The MusicManager will inherit from SoundManager. It will pseudo-randomly choose music sounds to play. It will consist of:
  - All inherited fields and methods
  - An array of MusicSounds that will hide the inherited array of Sounds
  - Play( ) will have to overlap MusicSounds
  	- Different modes depending on situation
		- Ambient
		- Combat
		- Boss fight
		- Etc.
