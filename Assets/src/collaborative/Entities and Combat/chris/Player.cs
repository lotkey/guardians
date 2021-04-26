using UnityEngine;

public class Player : Entity
{
    public PlayerArmsAnimator playerArmsAnimator;
    public static Player instance = null;
    public bool nearPickable = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("There are multiple players! This is bad!");
        }
    } 

    void Update()
    {
        
    }

    public static Player GetPlayer()
    {
        return instance;
    }
}
