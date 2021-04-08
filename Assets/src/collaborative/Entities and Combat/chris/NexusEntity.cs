using UnityEngine;

public class NexusEntity : Entity
{
    public static NexusEntity instance;

    public static NexusEntity GetInstance()
    {
        return instance;
    }

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            Debug.Log("Nexus already exists!");
        }

        /*if (body == null)
        {
            body = gameObject.AddComponent<Rigidbody2D>();
            body.gravityScale = 0;
            body.freezeRotation = true;
            body.mass = 1000000;
        }*/

        if (combat == null)
        {
            Debug.LogError("No combat script attached to the Nexus!");
        }
    }
}