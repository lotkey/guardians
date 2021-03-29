using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public PlayerController controller;
    public EntityAnimator playerArmsAnimator;
    public static Player instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static Player GetPlayer()
    {
        return instance;
    }
}
