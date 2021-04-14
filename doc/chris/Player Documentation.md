# The Player Entity
Chris McVickar  
IT Manager  
Pseudo Random Studios (PRS)

## An Overview
---

To fully reap the rewards of dynamic binding much of the Player system extends the Entity system. The Player system consists of these classes:
- Player : Entity
- PlayerCombat : EntityCombat
- PlayerMovement : EntityMovement
- PlayerController

## Classes
---

### Player : Entity

The Player class inherits from the Entity class, meaning that all fields and methods of the Entity class are inherited. However, dynamic binding is used. The Entity class contains references to an EntityCombat and an EntityMovement. The Player also contains these references. The static type of these references remain as EntityCombat and EntityMovement, but the dynamic types are PlayerCombat and PlayerMovement.

The Player is also a singleton, unlike the base Entity class. 

### PlayerCombat : EntityCombat

The PlayerCombat class inherits from EntityCombat. It adds some new features and is geared towards the player specifically.

**Additional fields (not present in EnityCombat):**
- invincibilityCooldown
  - Floating point number
  - Length of invincibility cooldown
  - Activated after taking damage
- invincibilityCooldownEndTime
  - Floating point number
  - Time when invincibility cooldown ends
- respawnPoint
  - Vector2D
  - Point where the player respawns
- isInvincible
  - Boolean
  - Indicates whether or not the player is invincible for Dr. BC Mode
- nonInvincibleDamage
  - Floating point number
  - Stores attack damage of weapon for switching in and out of Dr. BC Mode

**Additional methods (not present in EntityCombat):**
- SetInvincible(bool invincibility)
  - Toggles Dr. BC Mode

**Overridden EntityCombat methods:**
- Attack()
  - Checks for invincibility before attacking
- Die()
  - Respawns player
  - Sets health
- Heal(float amount)
  - Heals the player and updates the HUD
- TakeDamage(float amount)
  - Takes damage and updates the HUD

### PlayerMovement : EntityMovement

As of 4/13/2021 the PlayerMovement class does not differ from the EntityMovement class. Plans include to override the Dash() function in EntityMovement.

### PlayerController : MonoBehaviour

PlayerMovement is not a controller script. It is used to control the player's movement, but it is not a controller. Therefore, there needs to be a controller script.

**Fields:**
- player
  - Player
  - Reference to the player to control
- vertical, horizontal
  - Floating point numbers
  - Stores the vertical and horizontal input axes
- attack, attackHold
  - Booleans
  - Stores whether the attack button is pressed and whether the attack button is held
- dash
  - Boolean
  - Stores whether the dash button is pressed or not
- mousePos
  - Vector2
  - Stores the position of the mouse in the game
  - Used for rotation of the player

**Methods:**
- Update()
  - Get all keyboard and mouse input and store it in variables
- FixedUpdate()
  - Execute all movement through the movement script
- RotatePlayer()
  - Rotate player to face the player's cursor