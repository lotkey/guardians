using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This code handles the spawning of new rooms from room points. Room points exist on the outside of
 * doorways. The code is also a source of dynamic programming, as there exist certain rooms for which
 * it does not make sense to spawn random rooms. The most prominent example of this is the points that
 * spawn off of the sides of their rooms, where we don't want to spawn additional rooms that split off
 * to the sides or we would circle back on ourselves.
 */

public class RoomScript : MonoBehaviour
{
    // These are the rooms that can be spawned, listed for access by the script. The code will randomly
    // choose one, and instantiate the prebuilt prefab at the location of the room point
    public GameObject Collapse1, Collapse2, Collapse3, Fish, Gem, SmallRm, Tunnel1, Tunnel2, Tunnel3, Tunnel4,
        Multi, Arena, Split1, Split2, Split3, Cathedral, Switchback, Stlth, Tri, Spade;
    // There must be an offset to allow for the rooms to spawn correctly adjacent regarless of orientation,
    // thought the variable names is not accurate as "angle"
    float angleX, angleY;
    // This variable allows for choosing of rooms only fit for certain sides
    int side;

    // Start is called before the first frame update
    // We need to set a variable, then spawn the room
    void Start()
    {
        //This seed is the room randomly chosen of the first 16 available
        int seed = Random.Range(0, 16);

        // Call the spawning function with the seed generated
        Spawn(seed);
    }

    // The spawning function determines the offsets, rotation, and room to be spawned, yet we
    // allow it to be overridden in the event different spawning rules would be better or
    // necessary
    public virtual void Spawn(int seed) 
    { 
        // If the room goes upward from the cavern
        if(transform.rotation.eulerAngles.z == 90f)
        {
            // Shift the x and y exactly as far as the rooms are from the origin in their prefab
            angleX = -0.5f;
            angleY = 9.5f;
            // Set an additional offset for the allowance of different rooms than the others
            side = 3;
        }
        // If the room goes downward from the cavern
        else if(transform.rotation.eulerAngles.z == 270f)
        {
            // Shift the x and y as far from the origin as they are in the prefab to match up to a bottom point
            angleX = 0.5f;
            angleY = -9.5f;
            // Allow for different rooms to spawn on the bottom than from the top or sides
            side = 2;
        }
        // If the room goes to the right from the cavern
        else
        {
            // Shift the x and y as necessary, but it must be swapped in order for it to work this direction
            angleX = 9.5f;
            angleY = 0.5f;
            // Less rooms are allowed for the right paths, since they are two that are too close for bigger rooms
            side = 0;
        }


        // A switch case based on the random seed and the additional potentials factored in
        switch (seed+side)
        {
            case 0: // Not available for rooms due upward or downward
                Instantiate(Collapse1, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 1: // Not available for rooms due upward or downward
                Instantiate(Collapse2, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 2: // Not available for rooms due upward
                Instantiate(Collapse3, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 3:
                Instantiate(Fish, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 4:
                Instantiate(Gem, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 5:
                Instantiate(SmallRm, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 6:
                Instantiate(Tunnel1, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 7:
                Instantiate(Tunnel2, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 8:
                Instantiate(Tunnel3, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 9:
                Instantiate(Tunnel4, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 10:
                Instantiate(Multi, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 11:
                Instantiate(Arena, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 12:
                Instantiate(Split1, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 13:
                Instantiate(Split2, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 14:
                Instantiate(Split3, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 15:
                Instantiate(Cathedral, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 16:
                Instantiate(Switchback, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 17: // Only available for room points due upward or downward, as the spade is a large room that splits to the sides
                Instantiate(Spade, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 18: // Only available for room points due upward or downward, as the Tri room is large and splits to the sides
                Instantiate(Tri, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 19: // Only available for room points due upward, as the "stealth" room is too large to be on the right sides
                Instantiate(Stlth, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            default: // If the numbers should somehow be outside our options, don't spawn a room
                // SHOULD HAVE SOME DEFAULT, maybe SmallRm?
                break;
        }

        //Once the room is spawned, the room point is unneeded and can be removed to despawn the object (invisible though it may be, it still has this script attached, and all the room objects associated)
        Object.Destroy(this.gameObject);

    }
}
