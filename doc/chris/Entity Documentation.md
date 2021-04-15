# Guardians Entity Structure
Chris McVickar  
IT Manager  
Pseudo Random Studios (PRS)

## An Overview
---

The Entity structure determines the foundation for all entities: players, enemies, nexuses. Since all of these entities are based on the same foundation there is a lot of room for dynamic binding.

Each Entity should be able to do the following:
- Move
- Be controlled
- Collide with obstacles
- Engage in combat with other entities

The following components fulfills those requirements:
- A Rigidbody2D
  - Collisions
  - Movement
- A movement script
  - Movement
  - Controlling
- A combat script
  - Engage in combat with other entities

## Classes
---

### EntityMovement : MonoBehaviour

The main job of the EntityMovement class is to move an Entity. The EntityMovement class also contains fields and methods useful for animation. The Movement class does not take any keyboard or mouse input. Something very important to make clear is that the EntityMovement script can control an Entity's movement, but it is not a controller. Instead, it can be used by a controller to control an Entity's movement.

**Fields:**
- entity
  - Entity
  - A reference to the Entity whose movement is being controlled
- timeSinceMovedVertically, timeSinceMovedHorizontally
  - Floating point numbers
  - Used for telling when an Entity is idle. Useful for animations
- isMoving
  - Boolean
  - Also used for telling when an Entity is idle

**Methods:**
- Update()
  - Update *isMoving* so that is stays accurate
- Move(float x, float y, float deltaTime)
  - Moves the Entity in the x direction and y direction an appropriate amount for *deltaTime*
- MoveX(float x, float deltaTime), MoveY(float y, float deltaTime)
  - Moves the Entity in either the x or y direction an appropriate amount for *deltaTime*
- Dash()
  - Virtual function
  - Does nothing
  - Used as an example for dynamic binding, although there are more appropriate examples in the combat system
- IsMoving()
  - Getter for isMoving
- DirectionFacingDegrees()
  - Returns a float value indicating what direction the Entity is facing in degrees
- DirectionFacingVector()
  - Returns a Vector2D value indicating what direction the Entity is facing
  - For example, facing North should be (1, 0), South should be (-1, 0), etc.

### EntityCombat : MonoBehaviour

The EntityCombat script and its components handle all combat interactions between Entities. It is not a controller. It can be used to control an Entity's combat.

**Fields:**
- weapon
  - Weapon
  - A reference to the Weapon that the Entity is wielding
  - The Weapon system is the responsibility of Cade Disselkoen, Quality Assurance Manager, although a lot of it was designed by myself
- entity
  - Entity
  - A reference to the Entity that the EntityCombat script is managing the combat of
- attackDamage
  - Floating point number
  - Base attack damage amount of an Entity (may or may not have been utilized for the Weapons system)
- health
  - Floating point number
  - Represents an Entity's amount of health, 0 meaning the Entity has died
- maxHealth
  - Floating point number
  - Represents an Entity's maximum possible amount of health
- deathTile
  - Unity Tile
  - Used for placing a tile on a tilemap for death (blood splatter, bones, etc.)
- tilemap
  - Unity Tilemap
  - Used for placing *deathTile*
- gridLayout
  - Unity GridLayout
  - Used for placing *deathTile* onto *tilemap*

**Methods:**
- SetMaxHealth(float amount)
  - Sets an Entity's *health* and *maxHealth* to *amount*
- GetHealth()
  - Returns an Entity's health
- GetNormalizedHealth()
  - Returns an Entity's health as a percentage of their maximum possible health
- TakeDamage(float amount)
  - Virtual function
  - Subtracts *amount* from *health* and calls *Die()* when *health* gets below or equal to 0
- Heal(float healAmount)
  - Virtual function
  - Adds health to *health* such that it does not exceed *maxHealth*
- Attack()
  - Virtual function
  - Makes the weapon that the Entity is wielding attack
- Die()
  - Virtual function
  - Destroys the Entity's game object
  - Places *deathTile* at the Entity's position (before death)