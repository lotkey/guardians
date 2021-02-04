# Guardians/Assets/prefabs/michael/
# Level Generation

Michael has the role of working on the generation of the rooms. The current plans stands that we will have
rooms pre-built and attached on to open paths to generate the level. The level design will need to allow
for dynamic construction, so that we can have random levels. Randomness can be a vital component of a game
for fun and replayability.

The level will feature a main room with the primary objective. In addition, it will have paths leading off
to side rooms. These may also be the source of the enemies assaulting the primary objective.
These side rooms will be available for the player to explore between waves of enemy attacks. This will risk
the player not being present during the enemy attack, as well as enemies within these side rooms. However,
these side rooms will be very valuable as well, as they will have prizes for clearing enemies out, coming
in the form of more powerful weapons and items. It may be impossible to clear more difficult waves without
these.

To accomplish this random generation, I intend to have the rooms act as large prefabs with small objects
that exist at the openings/doorways. Then, I can spawn paths or rooms on these objects, replacing them.
Eventually, there would be a limit, probably determined with a weighted random number generator, to the
number of rooms. It would stop as the room paths cap off with tougher rooms that don't have any other doors.

In terms of inheritance, the rooms will have several types, and would break into a parent base room, then
to rooms with different numbers of openings, and finally into end rooms.

The spawn objects could also use inheritance, as they will all need to be invisible in-game, spawn other
objects onto them, be they enemies, rooms, or items. There could easily be enough common traits to make it
an inherited system.
