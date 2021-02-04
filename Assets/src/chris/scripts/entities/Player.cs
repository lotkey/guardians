using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public PlayerController controller;
    public new PlayerMovement movement; // Overrides the default EntityMovement with a dedicated PlayerMovement
}
